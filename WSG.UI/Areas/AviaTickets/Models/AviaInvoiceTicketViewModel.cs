using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.UI.Areas.AviaTickets.Models
{
    public class AviaInvoiceTicketViewModel
    {
        public AviaInvoiceTicketViewModel()
        {
            TicketId = Guid.NewGuid();
        }

        public Guid TicketId { get; set; }
        public int? Number { get; set; }
        public string FullName { get; set; }
        public string TicketNumber { get; set; }
    }
}