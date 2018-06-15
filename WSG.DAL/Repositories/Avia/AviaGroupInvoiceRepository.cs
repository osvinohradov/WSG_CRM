using System;
using System.Collections.Generic;
using System.Linq;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;
using WSG.DAL.EF;
using System.Data.Entity;

namespace WSG.DAL.Repositories.Avia
{
    public class AviaGroupInvoiceRepository : IRepository<AviaGroupInvoice>
    {
        private DataContext db;

        public AviaGroupInvoiceRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<AviaGroupInvoice> GetAll()
        {
            return this.db.AviaGroupInvoices;
        }

        public AviaGroupInvoice Get(Guid id)
        {
            return this.db.AviaGroupInvoices.Find(id);
        }

        public AviaGroupInvoice Create(AviaGroupInvoice item)
        {
            return this.db.AviaGroupInvoices.Add(item);
        }

        public AviaGroupInvoice Update(AviaGroupInvoice item)
        {
            this.db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public AviaGroupInvoice Delete(Guid id)
        {
            AviaGroupInvoice aviaGroupInvoice = db.AviaGroupInvoices.Find(id);
            if (aviaGroupInvoice != null)
            {
                return this.db.AviaGroupInvoices.Remove(aviaGroupInvoice);
            }
            return null;
        }

        public IEnumerable<AviaGroupInvoice> Find(Func<AviaGroupInvoice, bool> predicate)
        {
            return this.db.AviaGroupInvoices.Where(predicate).ToList();
        }
    }
}
