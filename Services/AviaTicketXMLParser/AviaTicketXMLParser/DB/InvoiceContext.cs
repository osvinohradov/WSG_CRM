namespace AviaTicketXMLParser.DB
{
    using BLL.Entities.Invoice;
    using System;
    using System.Data.Entity;

    using System.Linq;

    public class InvoiceContext : DbContext
    {
        // Your context has been configured to use a 'InvoiceContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AviaTicketXMLParser.DB.InvoiceContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InvoiceContext' 
        // connection string in the application configuration file.
        public InvoiceContext()
            : base("name=InvoiceContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<AviaInvoice> Invoices { get; set; }
        public virtual DbSet<AviaInvoiceTicket> Tickets { get; set; }
        public virtual DbSet<AviaInvoiceFlight> Flights { get; set; }
    }
}