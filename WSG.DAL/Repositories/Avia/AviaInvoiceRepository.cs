using System;
using System.Collections.Generic;
using System.Linq;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;
using WSG.DAL.EF;
using System.Data.Entity;

namespace WSG.DAL.Repositories.Avia
{
    public class AviaInvoiceRepository : IRepository<AviaInvoice>
    {
        private DataContext db;

        public AviaInvoiceRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<AviaInvoice> GetAll()
        {
            return this.db.AviaInvoices.Include(avt => avt.AviaInvoiceTickets).Include(avf => avf.AviaInvoiceFlights);
        }

        public AviaInvoice Get(Guid id)
        {
            return this.db.AviaInvoices.Find(id);
        }

        public AviaInvoice Create(AviaInvoice item)
        {
            return this.db.AviaInvoices.Add(item);
        }

        public AviaInvoice Update(AviaInvoice item)
        {
            this.db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public AviaInvoice Delete(Guid id)
        {
            AviaInvoice aviaInvoice = db.AviaInvoices.Find(id);
            if(aviaInvoice != null)
            {
                return this.db.AviaInvoices.Remove(aviaInvoice);
            }
            return null;
        }

        public IEnumerable<AviaInvoice> Find(Func<AviaInvoice, bool> predicate)
        {
            return this.db.AviaInvoices.Where(predicate).ToList();
        }        
    }
}
