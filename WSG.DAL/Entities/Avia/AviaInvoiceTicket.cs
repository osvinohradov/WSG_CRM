using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Entities.Avia
{
    [Table("AviaInvoiceTicket")]
    public class AviaInvoiceTicket
    {
        public AviaInvoiceTicket()
        {
            AviaInvoiceTicketId = Guid.NewGuid();
        }
        [Key]
        public virtual Guid AviaInvoiceTicketId { get; set; }
        public virtual int? Number { get; set; }
        public virtual string FullName { get; set; }
        public virtual string TicketNumber { get; set; }

        public virtual Guid AviaInvoiceId { get; set; }
        public virtual AviaInvoice AviaInvoice { get; set; }
    }
}
