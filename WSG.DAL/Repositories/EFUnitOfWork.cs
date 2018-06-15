using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSG.DAL.Repositories.Avia;
using WSG.DAL.EF;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;
using System.Data.Entity;

namespace WSG.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DataContext db;
        private AviaGroupInvoiceRepository aviaGroupInvoiceRepository;
        private AviaInvoiceRepository aviaInvoiceRepository;
        private AviaInvoiceFligtsRepository aviaInvoiceFlightRepository;
        private AviaInvoiceTicketRepository aviaInvoiceTicketRepository;

        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            db = new DataContext(connectionString);
        }

        public IRepository<AviaGroupInvoice> AviaGroupInvoices
        {
            get
            {
                if (this.aviaGroupInvoiceRepository== null)
                    this.aviaGroupInvoiceRepository = new AviaGroupInvoiceRepository(db);
                return this.aviaGroupInvoiceRepository;
            }
        }

        public IRepository<AviaInvoice> AviaInvoices
        {
            get
            {
                if (this.aviaInvoiceRepository == null)
                    this.aviaInvoiceRepository = new AviaInvoiceRepository(db);
                return this.aviaInvoiceRepository;
            }
        }

        public IRepository<AviaInvoiceFlight> AviaInvoiceFlights
        {
            get
            {
                if (this.aviaInvoiceFlightRepository == null)
                    this.aviaInvoiceFlightRepository = new AviaInvoiceFligtsRepository(db);
                return this.aviaInvoiceFlightRepository;
            }
        }

        public IRepository<AviaInvoiceTicket> AviaInvoiceTickets
        {
            get
            {
                if (this.aviaInvoiceTicketRepository == null)
                    this.aviaInvoiceTicketRepository = new AviaInvoiceTicketRepository(db);
                return this.aviaInvoiceTicketRepository;
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
