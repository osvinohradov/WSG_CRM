using System;
using System.Collections.Generic;
using System.Linq;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;
using WSG.DAL.EF;
using System.Data.Entity;

namespace WSG.DAL.Repositories.Avia
{
    public class AviaInvoiceTicketRepository : IRepository<AviaInvoiceTicket>
    {
        private DataContext db;

        public AviaInvoiceTicketRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<AviaInvoiceTicket> GetAll()
        {
            return this.db.AviaInvoiceTickets;
        }

        public AviaInvoiceTicket Get(Guid id)
        {
            return this.db.AviaInvoiceTickets.Find(id);
        }

        public AviaInvoiceTicket Create(AviaInvoiceTicket item)
        {
            return this.db.AviaInvoiceTickets.Add(item);
        }

        public AviaInvoiceTicket Update(AviaInvoiceTicket item)
        {
            this.db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public AviaInvoiceTicket Delete(Guid id)
        {
            AviaInvoiceTicket aviaInvoiceTicket = db.AviaInvoiceTickets.Find(id);
            if (aviaInvoiceTicket != null)
            {
                return this.db.AviaInvoiceTickets.Remove(aviaInvoiceTicket);
            }
            return null;
        }

        public IEnumerable<AviaInvoiceTicket> Find(Func<AviaInvoiceTicket, bool> predicate)
        {
            return this.db.AviaInvoiceTickets.Where(predicate).ToList();
        }
    }
}
