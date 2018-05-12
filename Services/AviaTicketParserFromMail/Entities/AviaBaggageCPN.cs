using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTicketParserFromMail.Entities
{
    public class AviaBaggageCPN
    {
        public string OperatingCC { get; set; }
        public string Origin { get; set; }
        public string Dest { get; set; }
        public string ICW { get; set; }
        public string ExcessBaggage { get; set; }
        public string PcRatePerUnit { get; set; }
        public string RMKS { get; set; }
    }
}
