using System;
using System.Collections.Generic;
using System.Linq;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;
using WSG.DAL.EF;
using System.Data.Entity;

namespace WSG.DAL.Repositories.Avia
{
    public class AviaInvoiceFligtsRepository : IRepository<AviaInvoiceFlight>
    {
        private DataContext db;

        public AviaInvoiceFligtsRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<AviaInvoiceFlight> GetAll()
        {
            return this.db.AviaInvoiceFlights;
        }

        public AviaInvoiceFlight Get(Guid id)
        {
            return this.db.AviaInvoiceFlights.Find(id);
        }

        public AviaInvoiceFlight Create(AviaInvoiceFlight item)
        {
            return this.db.AviaInvoiceFlights.Add(item);
        }

        public AviaInvoiceFlight Update(AviaInvoiceFlight item)
        {
            this.db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public AviaInvoiceFlight Delete(Guid id)
        {
            AviaInvoiceFlight aviaInvoiceFlight = db.AviaInvoiceFlights.Find(id);
            if (aviaInvoiceFlight != null)
            {
                return this.db.AviaInvoiceFlights.Remove(aviaInvoiceFlight);
            }
            return null;
        }

        public IEnumerable<AviaInvoiceFlight> Find(Func<AviaInvoiceFlight, bool> predicate)
        {
            return this.db.AviaInvoiceFlights.Where(predicate).ToList();
        }
    }
}
