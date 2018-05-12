using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AviaTicketParserFromMail.Entities
{
    [XmlRoot(ElementName = "Baggage")]
    public class AviaBaggage
    {
        [XmlIgnore]
        public int AviaBaggageID { get; set; }
        [XmlAttribute("Number")]
        public string No { get; set; }
        public string Airport { get; set; }
        public string Date { get; set; }
        [XmlIgnore]
        public string Company { get; set; }
        public string  Initials { get; set; }
        public string NumberAN { get; set; }

        [XmlArray(ElementName = "CPN")]
        [XmlArrayItem("item")]
        public List<AviaBaggageCPN> CPN { get; set; }
    }
}
