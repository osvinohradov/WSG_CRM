using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.UI.Areas.AviaTickets.Models
{
    public class AviaInvoiceFlightViewModel
    {
        public AviaInvoiceFlightViewModel()
        {
            FlightId = Guid.NewGuid();
        }
        public Guid FlightId { get; set; }
        public int? Number { get; set; }
        public string FlightNumber { get; set; }
        public string Place { get; set; }
        public string ArrivalPlace { get; set; }
        public string DeliveryPlace { get; set; }
        public string ServiceKind { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}