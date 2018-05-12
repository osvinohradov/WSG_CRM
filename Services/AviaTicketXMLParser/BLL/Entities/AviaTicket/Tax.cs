using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class Tax
    {
        public Tax()
        {
            TaxId = Guid.NewGuid();
        }
        [Key]
        public Guid TaxId { get; set; }
        public double Amount { get; set; }
        public string TaxCode { get; set; }
        public string NatureCode { get; set; }

        public Ticket Ticket { get; set; }
        public Guid TicketId { get; set; }
    }
}
