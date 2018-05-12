using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace AviaTicketParserFromMail
{
    public class FlightInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Flight { get; set; }
        public string CL { get; set; }
        public string Date { get; set; }
        public string Dep { get; set; }
        public string FareBasis { get; set; }
        public string NVB { get; set; }
        public string NVA { get; set; }
        public string Bag { get; set; }
        public string ST { get; set; }
        public string ArrivalTime { get; set; }
        public string ArrivalDate { get; set; }
        public string Terminal { get; set; } = "";

        string info, date;

        public FlightInfo(string info, string date, string terminal)
        {
            this.info = info;
            this.date = date;

            Terminal = terminal;

            // Парсим всю первую информационную линию (в порядке объявления полей!)
            From = GetField(Field.FROM);
            Flight = GetField(Field.FLIGHT);
            CL = GetField(Field.CL);
            Date = GetField(Field.DATE);
            Dep = GetField(Field.DEP);
            FareBasis = GetField(Field.FAREBASIS);
            NVB = GetField(Field.NVB);
            NVA = GetField(Field.NVA);
            Bag = GetField(Field.BAG);
            ST = GetField(Field.ST);

            // Парсим по спец. методам
            To = GetDestination();
            ArrivalTime = GetArrivalInfo()[0];
            ArrivalDate = GetArrivalInfo()[1];
        }
        public FlightInfo() { }
        private enum Field
        {
            FROM = 17, FLIGHT = 8, CL = 3, DATE = 7, DEP = 9, FAREBASIS = 14, NVB = 6, NVA = 6, BAG = 5, ST = 2
        }

        private string GetField(Field type)
        {
            string result = "";

            for (int i = 0; i < (int)type; i++)
            {
                result += info[i];
            }

            info = info.Remove(0, (int)type);

            return DeleteWhitespaces(result);
        }
        private string GetDestination()
        {
            string result = "";

            for (int i = 0; i < 17; i++)
                result += date[i];

            return DeleteWhitespaces(result);
        }
        private string[] GetArrivalInfo()
        {
            string[] results = new string[2];

            results[0] = DeleteWhitespaces(date.Split(':')[1].Split('A')[0]);
            results[1] = DeleteWhitespaces(date.Split(':')[2]);

            return results;
        }
        private string DeleteWhitespaces(string input)
        {
            string output = "";

            if (input.Length > 0)
            {
                if (Regex.IsMatch(Convert.ToString(input[0]), "^[a-zA-Z0-9]+$"))
                    output += input[0];
            }

            for (int i = 1; i < input.Length; i++)
            {
                if (Regex.IsMatch(Convert.ToString(input[i]), "^[a-zA-Z0-9- ]+$"))
                    output += input[i];
            }

            return output;
        }
    }
}
