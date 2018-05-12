namespace AviaTicketXMLParser.DB
{
    using BLL.Entities.AviaTicket;
    using System.Data.Entity;

    public class AviaTicketModel : DbContext
    {
        // Your context has been configured to use a 'AviaTicketModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AviaTicketXMLParser.DB.AviaTicketModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AviaTicketModel' 
        // connection string in the application configuration file.
        public AviaTicketModel()
            : base("name=AviaTicketModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<AviaTicket> AviaXMLTickets { get; set; }
        public virtual DbSet<NameElement> NameElements { get; set; }
        public virtual DbSet<SsrDocs> SsrDocs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<AirSegment> AirSegments { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<History> Histories { get; set; }

        public virtual DbSet<Remark> Remarks { get; set; }
    }
}