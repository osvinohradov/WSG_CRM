using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities.Invoice
{
    [Table("AviaInvoiceTicket")]
    public class AviaInvoiceTicket
    {
        public AviaInvoiceTicket()
        {
            TicketId = Guid.NewGuid();
        }
        [Key]
        public Guid TicketId { get; set; }
        public int? Number { get; set; }
        public string FullName { get; set; }
        public string TicketNumber { get; set; }

        public Guid InvoiceId { get; set; }
        public AviaInvoice Invoice { get; set; }
    }
}