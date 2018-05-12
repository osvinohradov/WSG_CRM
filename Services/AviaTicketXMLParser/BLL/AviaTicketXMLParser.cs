using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BLL.Entities.AviaTicket;
using BLL.Entities.Invoice;

namespace BLL
{
    public class AviaTicketXMLParser : IDisposable
    {
        private XmlDocument xmlDocument;
        private FileStream fileStream;

        public AviaTicketXMLParser() { }

        public Task<AviaTicket> ParseTicket(string path)
        {
            return Task.Run(() =>
            {
                xmlDocument = new XmlDocument();
                AviaTicket ticket = new AviaTicket();

                try
                {
                    using (XmlReader reader = XmlReader.Create(path))
                    {
                        xmlDocument.Load(reader);
                    }
                    ticket.RecordLocator = GetValueOfProperty("RecordLocator");
                    ticket.CreationDate = GetValueOfProperty("CreationDate");
                    ticket.OfficeidBooking = GetValueOfProperty("OfficeidBooking");
                    ticket.AgentSignBooking = GetValueOfProperty("AgentSignBooking");
                    ticket.ChangeDate = GetValueOfProperty("ChangeDate");
                    ticket.LastTransactionDate = GetValuesOfProperty("LastTransactionDate");
                    ticket.NameElement = GetNameElements("NameElement");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: something went wrong with open XML file.\n{ex.Message}", "Error", MessageBoxButtons.OK);
                }
                return ticket;
            });            
        }

        public string GetValueOfProperty(string propertyName)
        {
            var elements = this.xmlDocument.GetElementsByTagName(propertyName);
            return elements.Item(0).InnerText;
        }

        public XmlNodeList GetChildNodesByName(string proppertyName)
        {
            return this.xmlDocument.GetElementsByTagName(proppertyName).Item(0).ChildNodes;
        }

        public ICollection<string> GetValuesOfProperty(string propertyName)
        {
            List<string> properties = new List<string>();
            var elements = this.xmlDocument.GetElementsByTagName(propertyName);
            for (int i = 0; i < elements.Count; i++)
            {
                properties.Add(elements.Item(i).InnerText);
            }
            return properties;
        }

        public ICollection<NameElement> GetNameElements(string typeName)
        {
            List<NameElement> nameElementsList = new List<NameElement>();

            if (typeName == "NameElement")
            {
                XmlNodeList innerElement = GetChildNodesByName("NameElement");

                for (int i = 0; i < innerElement.Count; i++)
                {
                    NameElement nameElement = new NameElement();
                    var items = innerElement.Item(i);
                    var nodes = items.Cast<XmlNode>();
                    foreach (XmlNode node in nodes)
                    {
                        switch (node.Name)
                        {
                            case "Tattoo":
                                {
                                    nameElement.Tattoo = Convert.ToInt32(node.InnerText);
                                    break;
                                }
                            case "ElementNo":
                                {
                                    nameElement.ElementNo = Convert.ToInt32(node.InnerText);
                                    break;
                                }
                            case "LastName":
                                {
                                    nameElement.LastName = node.InnerText;
                                    break;
                                }
                            case "FirstName":
                                {
                                    nameElement.FirstName = node.InnerText;
                                    break;
                                }
                            case "Title":
                                {
                                    nameElement.Title = node.InnerText;
                                    break;
                                }
                            default:
                                {
                                    //Console.WriteLine($"Property {node.Name} not assign!");
                                    break;
                                }
                        }
                    }

                    List<SsrDocs> ssrDocsList = new List<SsrDocs>();
                    XmlNodeList ssrDocsElements = GetChildNodesByName("SsrDocs");
                    for (int j = 0; j < ssrDocsElements.Count; j++)
                    {
                        SsrDocs ssrDocs = new SsrDocs();
                        items = ssrDocsElements.Item(j);
                        nodes = items.Cast<XmlNode>();
                        foreach (XmlNode node in nodes)
                        {
                            switch (node.Name)
                            {
                                case "AirlineCode":
                                    {
                                        ssrDocs.AirlineCode = node.InnerText;
                                        break;
                                    }
                                case "DocType":
                                    {
                                        ssrDocs.DocType = node.InnerText;
                                        break;
                                    }
                                case "DocCountry":
                                    {
                                        ssrDocs.DocCountry = node.InnerText;
                                        break;
                                    }
                                case "DocNumber":
                                    {
                                        ssrDocs.DocNumber = node.InnerText;
                                        break;
                                    }
                                case "PaxCountry":
                                    {
                                        ssrDocs.PaxCountry = node.InnerText;
                                        break;
                                    }
                                case "BirthDate":
                                    {
                                        ssrDocs.BirthDate = node.InnerText;
                                        break;
                                    }
                                case "Gender":
                                    {
                                        ssrDocs.Gender = node.InnerText;
                                        break;
                                    }
                                case "ExpiryDate":
                                    {
                                        ssrDocs.ExpiryDate = node.InnerText;
                                        break;
                                    }
                                case "LastName":
                                    {
                                        ssrDocs.LastName = node.InnerText;
                                        break;
                                    }
                                case "FirstName":
                                    {
                                        ssrDocs.FirstName = node.InnerText;
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                        ssrDocsList.Add(ssrDocs);
                    };
                    nameElement.SsrDocs = ssrDocsList;

                    List<Ticket> ticketsList = new List<Ticket>();
                    XmlNodeList ticketsElements = GetChildNodesByName("Ticket");
                    for (int k = 0; k < ticketsElements.Count; k++)
                    {
                        Ticket ticket = new Ticket();
                        var ticketNodes = ticketsElements.Item(k).Cast<XmlNode>();
                        foreach (XmlNode node in ticketNodes)
                        {
                            switch (node.Name)
                            {
                                case "OfficeidTicketing":
                                    {
                                        ticket.OfficeidTicketing = node.InnerText;
                                        break;
                                    }
                                case "Status":
                                    {
                                        ticket.Status = node.InnerText;
                                        break;
                                    }
                                case "No":
                                    {
                                        ticket.No = node.InnerText;
                                        break;
                                    }
                                case "IataAgencyCode":
                                    {
                                        ticket.IataAgencyCode = node.InnerText;
                                        break;
                                    }
                                case "ValidatingCarrier":
                                    {
                                        ticket.ValidatingCarrier = node.InnerText;
                                        break;
                                    }
                                case "DocCurrency":
                                    {
                                        ticket.DocCurrency = node.InnerText;
                                        break;
                                    }
                                case "FareCurrency":
                                    {
                                        ticket.FareCurrency = node.InnerText;
                                        break;
                                    }
                                case "Fare":
                                    {
                                        ticket.Fare = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "FareEquiv":
                                    {
                                        ticket.FareEquiv = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "FareRate":
                                    {
                                        ticket.FareRate = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "DocTotal":
                                    {
                                        ticket.DocTotal = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "DocGrandTotal":
                                    {
                                        ticket.DocGrandTotal = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "MiscellaneousFeesTotal":
                                    {
                                        ticket.MiscellaneousFeesTotal = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "MiscellaneousFeesVatTotal":
                                    {
                                        ticket.MiscellaneousFeesVatTotal = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "TaxTotal":
                                    {
                                        ticket.TaxTotal = Convert.ToDouble(node.InnerText);
                                        break;
                                    }
                                case "Commission":
                                    {
                                        ticket.Commission = node.InnerText;
                                        break;
                                    }
                                case "TourCode":
                                    {
                                        ticket.TourCode = node.InnerText;
                                        break;
                                    }
                                case "Endorsement":
                                    {
                                        ticket.Endorsement = node.InnerText;
                                        break;
                                    }
                                case "Type":
                                    {
                                        ticket.Type = node.InnerText;
                                        break;
                                    }
                                case "Ttype":
                                    {
                                        ticket.Ttype = node.InnerText;
                                        break;
                                    }
                                case "FlightClass":
                                    {
                                        ticket.FlightClass = node.InnerText;
                                        break;
                                    }
                                case "OrigCity":
                                    {
                                        ticket.OrigCity = node.InnerText;
                                        break;
                                    }
                                case "DestCity":
                                    {
                                        ticket.DestCity = node.InnerText;
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }


                        // Парсим сегменты авиа маршрутов
                        List<AirSegment> airSegmentList = new List<AirSegment>();
                        XmlNodeList airSegmentsElements = GetChildNodesByName("AirSegment");
                        for (int m = 0; m < airSegmentsElements.Count; m++)
                        {
                            AirSegment airSegment = new AirSegment();
                            var airNodes = airSegmentsElements.Item(m).Cast<XmlNode>();
                            foreach (XmlNode node in airNodes)
                            {
                                switch (node.Name)
                                {
                                    case "No":
                                        {
                                            airSegment.No = Convert.ToInt32(node.InnerText);
                                            break;
                                        }
                                    case "ServiceCarrier":
                                        {
                                            airSegment.ServiceCarrier = node.InnerText;
                                            break;
                                        }
                                    case "FlightNo":
                                        {
                                            airSegment.FlightNo = node.InnerText;
                                            break;
                                        }
                                    case "AirClass":
                                        {
                                            airSegment.AirClass = node.InnerText;
                                            break;
                                        }
                                    case "BkgClass":
                                        {
                                            airSegment.BkgClass = node.InnerText;
                                            break;
                                        }
                                    case "DepartureDate":
                                        {
                                            airSegment.DepartureDate = node.InnerText;
                                            break;
                                        }
                                    case "DepartureTime":
                                        {
                                            airSegment.DepartureTime = node.InnerText;
                                            break;
                                        }
                                    case "ArrivalDate":
                                        {
                                            airSegment.ArrivalDate = node.InnerText;
                                            break;
                                        }
                                    case "ArrivalTime":
                                        {
                                            airSegment.ArrivalTime = node.InnerText;
                                            break;
                                        }
                                    case "FareBasis":
                                        {
                                            airSegment.FareBasis = node.InnerText;
                                            break;
                                        }
                                    case "BaggageAllow":
                                        {
                                            airSegment.BaggageAllow = node.InnerText;
                                            break;
                                        }
                                    case "Meal":
                                        {
                                            airSegment.Meal = node.InnerText;
                                            break;
                                        }
                                    case "TerminalArrival":
                                        {
                                            airSegment.TerminalArrival = node.InnerText;
                                            break;
                                        }
                                    case "FlightDurationTime":
                                        {
                                            airSegment.FlightDurationTime = node.InnerText;
                                            break;
                                        }
                                    case "Mileage":
                                        {
                                            airSegment.Mileage = node.InnerText;
                                            break;
                                        }
                                    case "Equipment":
                                        {
                                            airSegment.Equipment = node.InnerText;
                                            break;
                                        }
                                    case "AcRecLoc":
                                        {
                                            airSegment.AcRecLoc = node.InnerText;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }

                            // Парсим аэропорты
                            Airport origAirport = new Airport();
                            var origNodes = GetChildNodesByName("OrigAirport").Cast<XmlNode>();
                            foreach (XmlNode node in origNodes)
                            {
                                switch (node.Name)
                                {
                                    case "Code":
                                        {
                                            origAirport.Code = node.InnerText;
                                            break;
                                        }
                                    case "AmaName":
                                        {
                                            origAirport.AmaName = node.InnerText;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine($"Property {node.Name} not assign!");
                                            break;
                                        }
                                }
                            }
                            airSegment.OrigAirport = origAirport;
                            Airport destAirport = new Airport();
                            var destNodes = GetChildNodesByName("DestAirport").Cast<XmlNode>();
                            foreach (XmlNode node in destNodes)
                            {
                                switch (node.Name)
                                {
                                    case "Code":
                                        {
                                            destAirport.Code = node.InnerText;
                                            break;
                                        }
                                    case "AmaName":
                                        {
                                            destAirport.AmaName = node.InnerText;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine($"Property {node.Name} not assign!");
                                            break;
                                        }
                                }
                            }
                            airSegment.DestAirport = destAirport;

                            airSegmentList.Add(airSegment);
                        };
                        // Парсим таксы билетов
                        List<Tax> taxesList = new List<Tax>();
                        XmlNodeList taxesElements = GetChildNodesByName("Tax");
                        for (int n = 0; n < taxesElements.Count; n++)
                        {
                            Tax tax = new Tax();
                            var taxNode = taxesElements.Item(n).Cast<XmlNode>();
                            foreach (XmlNode node in taxNode)
                            {
                                switch (node.Name)
                                {
                                    case "Amount":
                                        {
                                            tax.Amount = Convert.ToDouble(node.InnerText);
                                            break;
                                        }
                                    case "TaxCode":
                                        {
                                            tax.TaxCode = node.InnerText;
                                            break;
                                        }
                                    case "NatureCode":
                                        {
                                            tax.NatureCode = node.InnerText;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine($"Property {node.Name} not assign!");
                                            break;
                                        }
                                }
                            }
                            taxesList.Add(tax);
                        };

                        // Получаем иформацию об истории
                        List<History> historyList = new List<History>();
                        XmlNodeList historyElements = GetChildNodesByName("History");
                        for (int q = 0; q < historyElements.Count; q++)
                        {
                            History history = new History();
                            var historyNodes = historyElements.Item(q).Cast<XmlNode>();
                            foreach (XmlNode node in historyNodes)
                            {
                                switch (node.Name)
                                {
                                    case "Action":
                                        {
                                            history.Action = node.InnerText;
                                            break;
                                        }
                                    case "ActionDate":
                                        {
                                            history.ActionDate = node.InnerText;
                                            break;
                                        }
                                    case "AirFile":
                                        {
                                            history.AirFile = node.InnerText;
                                            break;
                                        }
                                    case "AgentSign":
                                        {
                                            history.AgentSign = node.InnerText;
                                            break;
                                        }
                                    case "Amount":
                                        {
                                            history.Amount = node.InnerText;
                                            break;
                                        }
                                    case "NationalAmount":
                                        {
                                            history.NationalAmount = node.InnerText;
                                            break;
                                        }
                                    case "NationalCurrency":
                                        {
                                            history.NationalCurrency = node.InnerText;
                                            break;
                                        }
                                    case "FormOfPayment":
                                        {
                                            history.FormOfPayment = node.InnerText;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine($"Property {node.Name} not assign!");
                                            break;
                                        }
                                }
                            }
                            historyList.Add(history);
                        }
                        ticket.History = historyList;
                        ticket.AirSegment = airSegmentList;
                        ticket.Tax = taxesList;
                        ticketsList.Add(ticket);
                    }

                    nameElement.Ticket = ticketsList;   // Add ticket to name collection
                    nameElementsList.Add(nameElement);  // Add nameElem to collection
                }
            }
            return nameElementsList;
        }

        public void Dispose()
        {
            if (this.fileStream != null)
            {
                this.fileStream.Close();
            }
        }
    }
    //public class AviaXMLParser
    //{
    //    public void Parse()
    //    {
    //        try
    //        {
    //            var invoice = new Mapper(aviaTicket, new AviaInvoice()).Map();

    //            this._SaveToDb(aviaTicket, invoice);
    //        }
    //        catch (Exception ex)
    //        {
    //            string logStr = $"Date: {DateTime.Now}\nMessage:{ex.Message}\n{ex.StackTrace}\n\n";
    //            using (StreamWriter writer = new StreamWriter(this.LogErrorFileName, true, Encoding.UTF8))
    //            {
    //                writer.WriteLine(logStr);
    //            }
    //            System.Windows.MessageBox.Show("Під час парсингу сталася помикла, за більш детальною інофрмацією зверніться до файлу логів, або зверныться до адміністратора.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="ticketName">Путь к файлу с билетом</param>
    //    public void ParseOneTicket(string ticketName)
    //    {
    //        try
    //        {
    //            xmlDocument = new XmlDocument();
    //            MessageBox.Show(ticketName);
    //            xmlDocument.Load(ticketName);
    //            AviaXMLTicket aviaTicket = new AviaXMLTicket();
    //            aviaTicket.RecordLocator = GetValueOfProperty("RecordLocator");
    //            aviaTicket.CreationDate = GetValueOfProperty("CreationDate");
    //            aviaTicket.OfficeidBooking = GetValueOfProperty("OfficeidBooking");
    //            aviaTicket.AgentSignBooking = GetValueOfProperty("AgentSignBooking");
    //            aviaTicket.ChangeDate = GetValueOfProperty("ChangeDate");
    //            aviaTicket.LastTransactionDate = GetValuesOfProperty("LastTransactionDate");
    //            aviaTicket.NameElement = GetNameElements("NameElement");

    //            var invoice = new Mapper(aviaTicket, new AviaInvoice()).Map();
    //            this.xmlDocument = null;
    //            this._SaveToDb(aviaTicket, invoice);
    //        }
    //        catch (Exception ex)
    //        {
    //            string logStr = $"Date: {DateTime.Now}\nMessage:{ex.Message}\n{ex.StackTrace}\n\n";
    //            using (StreamWriter writer = new StreamWriter(this.LogErrorFileName, true, Encoding.UTF8))
    //            {
    //                writer.WriteLine(logStr);
    //            }
    //            System.Windows.MessageBox.Show("Під час парсингу сталася помикла, за більш детальною інофрмацією зверніться до файлу логів, або зверныться до адміністратора.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }
    //    }

    //    private void _SaveToDb(AviaXMLTicket ticket, AviaInvoice aviaInvoice)
    //    {
    //        try
    //        {
    //            using (AviaTicketModel db = new AviaTicketModel())
    //            {
    //                db.AviaXMLTickets.Add(ticket);
    //                db.SaveChanges();
    //            }
    //            using (InvoiceContext db = new InvoiceContext())
    //            {
    //                db.Invoices.Add(aviaInvoice);
    //                db.SaveChanges();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string logStr = $"Date: {DateTime.Now}\nMessage:{ex.Message}\n{ex.StackTrace}\n\n";
    //            using (StreamWriter writer = new StreamWriter(this.LogErrorFileName, true, Encoding.UTF8))
    //            {
    //                writer.WriteLine(logStr);
    //            }
    //            System.Windows.MessageBox.Show("Під час збереження квитка до БД сталася помикла, за більш детальною інофрмацією зверніться до файлу логів, або зверныться до адміністратора.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }
    //    }
}
