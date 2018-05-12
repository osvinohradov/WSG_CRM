using AviaTicketParserFromMail.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace AviaTicketParserFromMail
{
    public class Parser
    {
        // For Avia ticket and baggage
        private static string[] Lines { get; set; }
        // Only for baggage
        static int StartLine { get; set; }

        #region Avia Ticket Parser
        // ====================== Avia Ticket Parser ======================
        public AviaTicket ParseAviaTicket(string path)
        {
            AviaTicket ticket = new AviaTicket();
            try
            {
                string content = Extractor.Extract(path);
                Lines = content.Split('\r', '\n');

                #region Avia Ticket

                ticket.Date = GetValue("DATE");
                ticket.Agent = GetValue("AGENT");
                ticket.Name = GetValue("NAME");
                ticket.Fqtv = GetValue("FQTV");
                ticket.Iata = GetValue("IATA");
                ticket.Telephone = GetValue("TELEPHONE");
                ticket.IssuingAirline = GetValue("ISSUING AIRLINE");
                ticket.TicketNumber = GetValue("TICKET NUMBER");
                ticket.Endorsements = GetValue("ENDORSEMENTS");
                ticket.ExchangeRate = GetValue("EXCHANGE RATE");
                ticket.Payment = GetValue("PAYMENT");
                ticket.FareCalculation = GetValueFareCalculation("FARE CALCULATION");
                ticket.AirFare = GetValue("AIR FARE");
                ticket.EquivFarePaid = GetValue("EQUIV FARE PAID");
                ticket.AirlineSurcharges = GetValue("AIRLINE SURCHARGES");
                ticket.Total = GetValue("TOTAL");

                ticket.Tax = GetValueTax("TAX");
                ticket.FlightInfos = GetFlightsInfo() as FlightInfo[];

                #endregion

                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to convert.");
                Console.WriteLine(path);
            }

            return ticket;
        }
        private string GetValue(string value)
        {
            int? line = null;

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(value) && Lines[i].Contains(':'))
                {
                    line = i;
                    break;
                }
            }

            if (line != null)
            {
                string[] tmp = Lines[(int)line].Split(':');
                string add = tmp[1].Remove(0, 1);
                add = add.Replace(' ', ' ');
                return add;
            }
            else
                return null;
        }
        private string GetValueFareCalculation(string value)
        {
            int? line = null;

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(value) && Lines[i].Contains(':'))
                {
                    line = i;
                    break;
                }
            }

            if (line != null)
            {
                string[] tmp = Lines[(int)line].Split(':');
                string add = tmp[1].Remove(0, 1);
                add += '\n' + Lines[(int)line + 1];
                add = add.Replace(' ', ' ');
                return add;
            }
            else
                return null;
        }
        private List<string> GetValueTax(string value)
        {
            int? line = null;

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(value) && Lines[i].Contains(':'))
                {
                    line = i;
                    break;
                }
            }

            if (line != null)
            {
                string[] tmp = Lines[(int)line].Split(':');
                string add = tmp[1].Remove(0, 1);

                int current = (int)line + 1;
                while (!Lines[current].Contains("AIRLINE SURCHARGES"))
                {
                    add += '\n' + Lines[current];
                    current++;
                }

                tmp = add.Split('\n', ' ', ' ');

                List<string> tempCollection = new List<string>();
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (Regex.IsMatch(tmp[i], "^[a-zA-Z0-9]+$"))
                        tempCollection.Add(tmp[i]);
                }

                List<string> result = new List<string>();

                int j = 0;
                while (j < tempCollection.Count)
                {
                    result.Add(tempCollection[j] + " " + tempCollection[j + 1]);
                    j += 2;
                }

                return result;
            }
            else
                return null;
        }
        private IEnumerable<FlightInfo> GetFlightsInfo()
        {
            int line = 0;

            // Determine the initial index of the first ticket
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains("FROM /TO"))
                {
                    line = i + 2;
                    break;
                };
            };

            // Create a collection, that stores the line numbers in which the terminal is located
            // Создаем коллекцию, в которой будут хранится терминалы
            //List<int> terminals = new List<int>();
            Dictionary<int, int> terminals = new Dictionary<int, int>();

            // Create a collection, that stores the line numbers in which the avia time is located
            // Создаем коллекцию, в которой будет хранится номера строк времени прибытия
            List<int> arrivalTimeLines = new List<int>();

            // Перебор всех терминальных строк
            for (int i = 0, j = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains("ARRIVAL TIME:"))
                {
                    arrivalTimeLines.Add(i);
                    j++;
                }

                if (Lines[i].Contains("TERMINAL:"))
                {
                    terminals.Add(j, i);
                }
            }

            bool isFlight = true;
            FlightInfo[] result = new FlightInfo[arrivalTimeLines.Count];

            int pos = 0;
            while (isFlight)
            {
                string terminal = null;

                //if (terminals.Count > pos)
                if (terminals.ContainsKey(pos))
                {
                    terminal = Lines[terminals[pos]].Split(':')[1];
                }

                result[pos] = new FlightInfo(Lines[line], Lines[arrivalTimeLines[pos]], terminal);

                // Идем к следующему билету
                // Попутно проверяем, а есть ли они вообще? (две пустые строки)
                for (int i = arrivalTimeLines[pos]; i < Lines.Length; i++)
                {
                    if (Lines[i].Length == 0 && Lines[i + 1].Length == 0)
                    {
                        isFlight = false;
                        break;
                    }
                    else if (Lines[i].Length == 0)
                    {
                        line = i + 1;
                        break;
                    }
                }

                pos++;
            }
            return result;
        }
        #endregion

        #region Avia Ticket Parser
        // ====================== Avia Baggage Parser ======================
        public AviaBaggage ParseAviaBaggage(string path)
        {
            AviaBaggage baggage = new AviaBaggage();

            try
            {
                string content = Extractor.Extract(path);
                Lines = content.Split('\r', '\n');

                for (int i = 0; i < Lines.Length; i++)
                {
                    if (Lines[i].Contains("**********************"))
                    {
                        StartLine = i;
                        break;
                    }
                }

                #region Forming AviaBaggage

                baggage.No = GetNumber();
                baggage.Airport = GetAirport();
                baggage.Date = GetFlightDate();
                baggage.Company = GetWorldServiceGroup();
                baggage.Initials = GetSurnameName();
                baggage.NumberAN = GetNumbersAfterName();
                baggage.CPN = GetFlightInfos();

                #endregion

                return baggage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return baggage;
        }

        private string GetNumber()
        {
            string result = "";

            for (int i = 0; i < 22; i++)
                result += Lines[StartLine + 1][i];

            return result.RemoveFirstWhiteSpaces();
        }
        private string GetAirport()
        {
            string result = "";

            for (int i = 0; i < 22; i++)
                result += Lines[StartLine + 3][i];

            return result.RemoveFirstWhiteSpaces();
        }
        private string GetFlightDate()
        {
            string result = "";

            for (int i = 23; i < 51; i++)
                result += Lines[StartLine + 3][i];

            return result.RemoveFirstWhiteSpaces();
        }
        private string GetWorldServiceGroup()
        {
            string result = "";

            for (int i = 23; i < 51; i++)
                result += Lines[StartLine + 4][i];

            return result.Split('/')[0].RemoveFirstWhiteSpaces();
        }
        private string GetSurnameName()
        {
            string result = "";

            for (int i = 0; i < 22; i++)
                result += Lines[StartLine + 5][i];

            return result.Replace('/', ' ').RemoveFirstWhiteSpaces();
        }
        private string GetNumbersAfterName()
        {
            string result = "";

            for (int i = 23; i < 51; i++)
                result += Lines[StartLine + 5][i];

            return result.Split('/')[0].RemoveFirstWhiteSpaces();
        }
        private List<AviaBaggageCPN> GetFlightInfos()
        {
            List<AviaBaggageCPN> list = new List<AviaBaggageCPN>();
            List<int> positions = new List<int>();

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains("CPN"))
                {
                    positions.Add(i);
                }
            }

            foreach (int number in positions)
            {
                AviaBaggageCPN AviaBaggageCPN = new AviaBaggageCPN();
                AviaBaggageCPN.OperatingCC = Lines[number + 1].Split(':')[1];
                AviaBaggageCPN.Origin = Lines[number + 2].Split(':')[1];
                AviaBaggageCPN.Dest = Lines[number + 3].Split(':')[1];
                AviaBaggageCPN.ICW = Lines[number + 5].Split(':')[1].RemoveFirstWhiteSpaces();
                AviaBaggageCPN.ExcessBaggage = Lines[number + 6].Split(':')[1].Replace("PC RATE PER UNIT", "").RemoveFirstWhiteSpaces();
                AviaBaggageCPN.PcRatePerUnit = Lines[number + 6].Split(':')[2].RemoveFirstWhiteSpaces();
                AviaBaggageCPN.RMKS = Lines[number + 7].Split(':')[1].RemoveFirstWhiteSpaces();
                list.Add(AviaBaggageCPN);
            }

            return list;
        }

        private string GetValue(string key, int whitespaces)
        {
            int line = -1;
            whitespaces++;

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(key))
                {
                    line = i;
                    break;
                }
            }

            if (line != -1)
            {
                string tmp = Lines[line].RemoveIncluding(key);

                int currentWhitespaces = 0;
                string value = "";
                bool nextLine = false;

                for (int j = 0; j < tmp.Length; j++)
                {
                    if (j == 0)
                    {
                        if (tmp[j] == ' ')
                            continue;
                        if (tmp[j] == '&')
                        {
                            nextLine = true;
                            break;
                        }
                    }

                    if (tmp[j] == ' ' || tmp[j] == '&')
                    {
                        currentWhitespaces++;

                        if (currentWhitespaces == whitespaces)
                            break;

                        value += " ";

                        if (tmp[j] == '&')
                        {
                            nextLine = true;
                            break;
                        }
                    }
                    else
                        value += tmp[j];
                }

                if (nextLine)
                {
                    tmp = Lines[line + 1];

                    if (tmp != null)
                    {
                        if (tmp[0] != '&')
                        {
                            int k = 0;
                            while (currentWhitespaces != whitespaces)
                            {
                                if (tmp[k] != ' ')
                                    value += tmp[k];
                                else
                                    currentWhitespaces++;

                                k++;
                            }
                        }
                    }
                }

                return value;
            }

            return null;
        }
        #endregion        
    }

    static class StringExtension
    {
        public static string RemoveFirstWhiteSpaces(this string working)
        {
            string result = "";
            bool found = false;

            string pattern = "^[a-zA-Z0-9]+$";

            for (int i = 0; i < working.Length; i++)
            {
                if (found == false)
                {
                    if (Regex.IsMatch(Convert.ToString(working[i]), pattern))
                        found = true;
                }

                if (found)
                    result += working[i];
            }

            return result;
        }
        public static string RemoveIncluding(this string working, string key)
        {
            string word = "";
            bool contains = false;
            int position = 0;

            for (int i = 0; i < working.Length; i++)
            {
                word += working[i];
                if (word.Contains(key))
                {
                    contains = true;
                    position = i + 1;
                    break;
                }
            }

            if (contains)
            {
                string result = working.Remove(0, position);
                return result;
            }
            else
                return working;
        }
    }
}
