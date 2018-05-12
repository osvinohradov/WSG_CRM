namespace AviaTicketParserFromMail.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int TicketId { get; set; }

        [StringLength(50)]
        public string TicketNumber { get; set; }

        [StringLength(10)]
        public string Agent { get; set; }
    }
}
