using System;
using System.Collections.Generic;
using System.Linq;
using WSG.DAL.EF;
using WSG.DAL.Infrastructure;
using WSG.DAL.Models.Avia;
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
        public void Create(AviaInvoice invoice)
        {
            db.AviaInvoices.Add(invoice);
        }

        public void Delete(Guid id)
        {
            AviaInvoice invoice = db.AviaInvoices.Find(id);
            if(invoice != null)
            {
                db.AviaInvoices.Remove(invoice);
            }
        }

        public IEnumerable<AviaInvoice> Find(Func<AviaInvoice, bool> predicate)
        {
            return db.AviaInvoices.Where(predicate).ToList();
        }

        public IEnumerable<AviaInvoice> GetAll()
        {
            return db.AviaInvoices;
        }

        public AviaInvoice Get(Guid id)
        {
            return db.AviaInvoices.Find(id);
        }

        public void Update(AviaInvoice invoice)
        {
            db.Entry(invoice).State = EntityState.Modified;
        }
    }
}
