using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Models.Avia
{
    [Table("AviaInvoiceFlight")]
    public class AviaInvoiceFlight
    {
        [Key]
        public Guid FlightId { get; set; }
        public int? Number { get; set; }
        public string FlightNumber { get; set; }
        public string Place { get; set; }
        public string ArrivalPlace { get; set; }
        public string DeliveryPlace { get; set; }
        public string ServiceKind { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public Guid InvoiceId { get; set; }
        public AviaInvoice Invoice { get; set; }
    }
}
