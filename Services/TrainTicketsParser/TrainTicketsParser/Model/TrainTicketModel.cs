namespace TrainTicketsParser.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TrainTicketsParser.Entities;

    public class TrainTicketModel : DbContext
    {
        // Your context has been configured to use a 'TrainTicketModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TrainTicketsParser.Model.TrainTicketModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TrainTicketModel' 
        // connection string in the application configuration file.
        public TrainTicketModel()
            : base("name=TrainTicketModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<CounterPart> CounterPart { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<Insurer> Insurer { get; set; }

        public virtual DbSet<Invoice> Invoice { get; set; }

        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Price.Article> PriceArticle { get; set; }

        public virtual DbSet<SoldSeat> SoldSeat { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }

        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<Src> Src { get; set; }
        public virtual DbSet<Dst> Dst { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
    }
}