using System;

namespace WSG.BAL.DTO
{
    public class AviaInvoiceTicketDTO
    {
        public AviaInvoiceTicketDTO()
        {
            TicketId = Guid.NewGuid();
        }

        public Guid TicketId { get; set; }
        public int? Number { get; set; }
        public string FullName { get; set; }
        public string TicketNumber { get; set; }
    }
}
