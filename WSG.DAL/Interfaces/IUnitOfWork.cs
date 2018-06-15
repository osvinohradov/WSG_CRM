using System;
using WSG.DAL.Entities.Avia;
namespace WSG.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AviaInvoice> AviaInvoices { get; }
        IRepository<AviaInvoiceFlight> AviaInvoiceFlights { get; }
        IRepository<AviaInvoiceTicket> AviaInvoiceTickets { get; }
        IRepository<AviaGroupInvoice> AviaGroupInvoices { get; }
        void Save();
    }
}
