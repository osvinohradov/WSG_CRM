using System;
using System.Collections.Generic;
using WSG.BAL.DTO;

namespace WSG.BAL.Interfaces
{
    public interface IAviaInvoiceService
    {
        void MakeInvoice(AviaInvoiceDTO invoice);
        AviaInvoiceDTO GetInvoice(Guid id);
        IEnumerable<AviaInvoiceDTO> GetInvoices();
        IEnumerable<AviaInvoiceFlightDTO> GetFlights(Guid invoiceId);
        IEnumerable<AviaInvoiceTicketDTO> GetTickets(Guid invoiceId);

        void Dispose();
    }
}
