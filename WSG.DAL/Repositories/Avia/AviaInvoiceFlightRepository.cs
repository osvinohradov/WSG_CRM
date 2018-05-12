using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WSG.DAL.EF;
using WSG.DAL.Infrastructure;
using WSG.DAL.Models.Avia;

namespace WSG.DAL.Repositories.Avia
{
    public class AviaInvoiceFlightRepository : IRepository<AviaInvoiceFlight>
    {
        private DataContext db;

        public AviaInvoiceFlightRepository(DataContext context)
        {
            this.db = context;
        }
        public void Create(AviaInvoiceFlight flight)
        {
            db.AviaInvoiceFlights.Add(flight);
        }

        public void Delete(Guid id)
        {
            AviaInvoiceFlight flight = db.AviaInvoiceFlights.Find(id);
            if (flight != null)
            {
                db.AviaInvoiceFlights.Remove(flight);
            }
        }

        public IEnumerable<AviaInvoiceFlight> Find(Func<AviaInvoiceFlight, bool> predicate)
        {
            return db.AviaInvoiceFlights.Where(predicate).ToList();
        }

        public IEnumerable<AviaInvoiceFlight> GetAll()
        {
            return db.AviaInvoiceFlights;
        }

        public AviaInvoiceFlight Get(Guid id)
        {
            return db.AviaInvoiceFlights.Find(id);
        }

        public void Update(AviaInvoiceFlight flight)
        {
            db.Entry(flight).State = EntityState.Modified;
        }
    }
}
