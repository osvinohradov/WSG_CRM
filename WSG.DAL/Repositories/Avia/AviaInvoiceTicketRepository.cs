using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WSG.DAL.EF;
using WSG.DAL.Infrastructure;
using WSG.DAL.Models.Avia;

namespace WSG.DAL.Repositories.Avia
{
    class AviaInvoiceTicketRepository : IRepository<AviaInvoiceTicket>
    {
        private DataContext db;

        public AviaInvoiceTicketRepository(DataContext context)
        {
            this.db = context;
        }
        public void Create(AviaInvoiceTicket ticket)
        {
            db.AviaInvoiceTickets.Add(ticket);
        }

        public void Delete(Guid id)
        {
            AviaInvoiceTicket ticket = db.AviaInvoiceTickets.Find(id);
            if (ticket != null)
            {
                db.AviaInvoiceTickets.Remove(ticket);
            }
        }

        public IEnumerable<AviaInvoiceTicket> Find(Func<AviaInvoiceTicket, bool> predicate)
        {
            return db.AviaInvoiceTickets.Where(predicate).ToList();
        }

        public IEnumerable<AviaInvoiceTicket> GetAll()
        {
            return db.AviaInvoiceTickets;
        }

        public AviaInvoiceTicket Get(Guid id)
        {
            return db.AviaInvoiceTickets.Find(id);
        }

        public void Update(AviaInvoiceTicket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }
    }
}
