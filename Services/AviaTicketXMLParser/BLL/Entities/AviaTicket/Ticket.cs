using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class Ticket
    {
        public Ticket()
        {
            TicketId = Guid.NewGuid();
        }
        [Key]
        public Guid TicketId { get; set; }
        public string OfficeidTicketing { get; set; }
        public string Status { get; set; }
        public string No { get; set; }
        public string IataAgencyCode { get; set; }
        public string ValidatingCarrier { get; set; }
        public string DocCurrency { get; set; }
        public string FareCurrency { get; set; }
        public double Fare { get; set; }
        public double FareEquiv { get; set; }
        public double FareRate { get; set; }
        public double DocTotal { get; set; }
        public double DocGrandTotal { get; set; }
        public double MiscellaneousFeesTotal { get; set; }
        public double MiscellaneousFeesVatTotal { get; set; }
        public double TaxTotal { get; set; }
        public string Commission { get; set; }
        public string TourCode { get; set; }
        public string Endorsement { get; set; }
        public string Type { get; set; }
        public string Ttype { get; set; }
        public string FlightClass { get; set; }
        public string OrigCity { get; set; }
        public string DestCity { get; set; }

        public ICollection<AirSegment> AirSegment { get; set; }
        public ICollection<Tax> Tax { get; set; }
        public ICollection<History> History { get; set; }

        public NameElement NameElement { get; set; }
        public Guid NameElementId { get; set; }
    }
}
