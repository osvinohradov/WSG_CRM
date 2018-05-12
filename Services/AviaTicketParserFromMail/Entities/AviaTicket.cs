using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AviaTicketParserFromMail
{
    [XmlRoot(ElementName ="Ticket")]
    public class AviaTicket
    {
        [XmlIgnore]
        public int AviaTicketId { get; set; }
        public string Date { get; set; }
        public string Agent { get; set; }
        public string Name { get; set; }
        public string Fqtv { get; set; }
        public string Iata { get; set; }
        public string Telephone { get; set; }
        public string IssuingAirline { get; set; }
        public string TicketNumber { get; set; }
        public string Endorsements { get; set; }
        public string ExchangeRate { get; set; }
        public string Payment { get; set; }
        public string FareCalculation { get; set; }
        public string AirFare { get; set; }
        public string EquivFarePaid { get; set; }
        public string AirlineSurcharges { get; set; }
        public string Total { get; set; }

        [XmlArray(ElementName = "Tax")]
        [XmlArrayItem(ElementName ="item")]
        public List<string> Tax { get; set; }

        [XmlArray(ElementName = "FlightInfo")]
        [XmlArrayItem(ElementName = "item")]
        public FlightInfo[] FlightInfos { get; set; }
    }
}
