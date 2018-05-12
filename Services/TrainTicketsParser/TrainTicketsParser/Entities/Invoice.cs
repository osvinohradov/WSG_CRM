using System;
using System.ComponentModel.DataAnnotations;

namespace TrainTicketsParser.Entities
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }
        public string Id { get; set; } // Билет имеет поле ID
        public string OuterId { get; set; }
        public string SalePointName { get; set; }
        public string AspsCode { get; set; }
        public string AspsCode2 { get; set; }
        public int? State { get; set; }
        public int? IsElectronic { get; set; }
        public DateTime? CreationTime { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }

        public int? OwnerId { get; set; }
        public int? BoardingPass { get; set; }

        // For relationship one-to-one with Travel table
        public virtual Travel Travel { get; set; }

        // For relationship one-to-one with SoldSeat table
        public virtual SoldSeat SoldSeats { get; set; }

        // For relationship one-to-one with Price table
        public Price Price { get; set; }        

        // For relationship one-to-one with CounterPart table
        public virtual CounterPart CounterParts { get; set; }

        public Invoice()
        {
            InvoiceId = Guid.NewGuid();
        }
    }
}
