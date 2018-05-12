using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsParser.Entities
{
    public class Travel
    {
        [ForeignKey("Invoice")]
        public Guid TravelId { get; set; }

        public Guid GuidIdx { get; set; }

        public virtual Src Src { get; set; }
        public virtual Dst Dst { get; set; }

        public int? TransportType { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public string Duration { get; set; }

        // For relationship one-to-one with Trip table
        public virtual Trip Trip { get; set; }
        
        // For relationship one-to-one with Invoice table
        public virtual Invoice Invoice { get; set; }
    }

    public class Src
    {
        public Guid SrcId { get; set; }

        public string Idx { get; set; }
        public string Name { get; set; }

        public Src()
        {
            SrcId = Guid.NewGuid();
        }
    }
    
    public class Dst
    {
        public Guid DstId { get; set; }

        public string Idx { get; set; }
        public string Name { get; set; }

        public Dst()
        {
            DstId = Guid.NewGuid();
        }
    }

    public class Trip
    {
        [ForeignKey("Travel")]
        public Guid TripId { get; set; }

        public string Id { get; set; }

        public virtual Src Src { get; set; }
        public virtual Dst Dst { get; set; }

        public string Transporter { get; set; }
        public int? State { get; set; }
        public int? El { get; set; }
        public int? BoardingPass { get; set; }

        // For relationship one-to-one with Travel table
        public virtual Travel Travel { get; set; }
    }
}
