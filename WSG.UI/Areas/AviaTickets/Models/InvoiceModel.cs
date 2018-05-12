using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.UI.Areas.AviaTickets.Models
{
    public class InvoiceModel
    {
        public AviaInvoiceViewModel Invoice { get; set; }
        public IEnumerable<AviaInvoiceViewModel> Invoices { get; set; }
        public IEnumerable<AviaInvoiceFlightViewModel> InvoiceFlight { get; set; }
        public AviaInvoiceTicketViewModel InvoiceTicket { get; set; }
    }
}