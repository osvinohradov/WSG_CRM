using System;

namespace WSG.BAL.DTO.Avia
{
    public class AviaInvoiceTicketDTO
    {
        public AviaInvoiceTicketDTO()
        {
            AviaInvoiceTicketId = Guid.NewGuid();
        }

        public virtual Guid AviaInvoiceTicketId { get; set; }
        public virtual int? Number { get; set; }
        public virtual string FullName { get; set; }
        public virtual string TicketNumber { get; set; }

        public virtual Guid AviaInvoiceId { get; set; }
    }
}
