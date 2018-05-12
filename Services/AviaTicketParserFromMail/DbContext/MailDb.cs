namespace AviaTicketParserFromMail.DbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MailDb : DbContext
    {
        public MailDb()
            : base("name=MailDb")
        {
        }

        public virtual DbSet<Baggage> Baggages { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baggage>()
                .Property(e => e.BaggageNumber)
                .IsFixedLength();

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TicketNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Agent)
                .IsUnicode(false);
        }
    }
}
