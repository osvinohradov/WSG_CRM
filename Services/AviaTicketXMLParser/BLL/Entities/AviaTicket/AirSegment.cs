using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class AirSegment
    {
        public AirSegment()
        {
            AirSegmentId = Guid.NewGuid();
        }
        [Key]
        public Guid AirSegmentId { get; set; }
        public int No { get; set; }
        public string ServiceCarrier { get; set; }
        public string FlightNo { get; set; }
        public string AirClass { get; set; }
        public string BkgClass { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }

        public Airport OrigAirport { get; set; }

        public Airport DestAirport { get; set; }

        public string FareBasis { get; set; }
        public string BaggageAllow { get; set; }
        public string Meal { get; set; }
        public string TerminalArrival { get; set; }
        public string FlightDurationTime { get; set; }
        public string Mileage { get; set; }
        public string Equipment { get; set; }
        public string AcRecLoc { get; set; }

        public Ticket Ticket { get; set; }
        public Guid TicketId { get; set; }
    }
}
