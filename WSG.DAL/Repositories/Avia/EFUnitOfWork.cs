using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSG.DAL.EF;
using WSG.DAL.Infrastructure;
using WSG.DAL.Models.Avia;

namespace WSG.DAL.Repositories.Avia
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private DataContext db;
        private AviaInvoiceRepository aviaInvoiceRepository;
        private AviaInvoiceTicketRepository aviaInvoiceTicketRepository;
        private AviaInvoiceFlightRepository aviaInvoiceFlightRepository;

        public EFUnitOfWork(string connectionString)
        {
            this.db = new DataContext(connectionString);
        }

        public IRepository<AviaInvoice> AviaInvoice
        {
            get
            {
                if (aviaInvoiceRepository == null)
                {
                    aviaInvoiceRepository = new AviaInvoiceRepository(db);
                }
                return aviaInvoiceRepository;
            }
        }

        public IRepository<AviaInvoiceTicket> AviaInvoiceTicket
        {
            get
            {
                if(aviaInvoiceTicketRepository == null)
                {
                    aviaInvoiceTicketRepository = new AviaInvoiceTicketRepository(db);
                }
                return aviaInvoiceTicketRepository;
            }
        }

        public IRepository<AviaInvoiceFlight> AviaInvoiceFlight
        {
            get
            {
                if (aviaInvoiceFlightRepository == null)
                {
                    aviaInvoiceFlightRepository = new AviaInvoiceFlightRepository(db);
                }
                return aviaInvoiceFlightRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
