using System;
using System.Data.Entity;
using WSG.DAL.Models.Avia;

namespace WSG.DAL.EF
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString)
            :base(connectionString)
        {
        }

        public DbSet<AviaInvoice> AviaInvoices { get; set; }
        public DbSet<AviaInvoiceTicket> AviaInvoiceTickets { get; set; }
        public DbSet<AviaInvoiceFlight> AviaInvoiceFlights { get; set; }
    }
}
