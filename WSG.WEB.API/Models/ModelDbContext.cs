namespace WSG.WEB.API.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WSG.WEB.API.Models.Avia;

    public class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }
        
        public virtual DbSet<AviaInvoice> AviaInvoice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AviaInvoice>().ToTable("AviaInvoices");
        }
    }
}