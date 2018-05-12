using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Models.Avia
{
    [Table("AviaInvoiceTicket")]
    public class AviaInvoiceTicket
    {
        [Key]
        public Guid TicketId { get; set; }
        public int? Number { get; set; }
        public string FullName { get; set; }
        public string TicketNumber { get; set; }

        public Guid InvoiceId { get; set; }
        public AviaInvoice Invoice { get; set; }
    }
}
