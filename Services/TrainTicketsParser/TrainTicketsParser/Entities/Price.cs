using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsParser.Entities
{
    public class Price
    {
        [ForeignKey("Invoice")]
        public Guid PriceId { get; set; }

        public int? Total { get; set; }
        public int? Tax { get; set; }

        public IEnumerable<Article> Articles { get; set; }

        // For relationship one-to-one with Invoice table
        public virtual Invoice Invoice { get; set; }

        public class Article
        {
            [ForeignKey("Price")]
            public Guid ArticleId { get; set; }

            public int? Code { get; set; }
            public string Name { get; set; }
            public double? PriceField { get; set; }

            // For relationship one-to-one with Price table
            public virtual Price Price { get; set; }

        }
    }
}
