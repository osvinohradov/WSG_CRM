using System;
using System.Data.Entity;
using WSG.DAL.Entities.Avia;

namespace WSG.DAL.EF
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString)
            :base(connectionString)
        {
        }

        static DataContext()
        {
            Database.SetInitializer<DataContext>(new AviaInvoicesDbInitializer());
        }

        public DbSet<AviaInvoice> AviaInvoices { get; set; }
        public DbSet<AviaInvoiceTicket> AviaInvoiceTickets { get; set; }
        public DbSet<AviaInvoiceFlight> AviaInvoiceFlights { get; set; }
        public DbSet<AviaGroupInvoice> AviaGroupInvoices { get; set; }
    }

    public class AviaInvoicesDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        public override void InitializeDatabase(DataContext context)
        {
            context.AviaInvoices.Add(null);
            context.SaveChanges();
        }
    } 
}
