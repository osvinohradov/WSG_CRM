namespace AviaTicketParserFromMail.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baggage")]
    public partial class Baggage
    {
        public int BaggageId { get; set; }
        
        public string BaggageNumber { get; set; }
    }
}
