using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSG.DAL.Models.Avia;

namespace WSG.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<AviaInvoice> AviaInvoice { get; }
        IRepository<AviaInvoiceTicket> AviaInvoiceTicket { get; }
        IRepository<AviaInvoiceFlight> AviaInvoiceFlight { get; }
        void Dispose();
    }
}
