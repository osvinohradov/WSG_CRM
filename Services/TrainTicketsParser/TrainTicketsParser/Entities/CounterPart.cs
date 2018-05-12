using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsParser.Entities
{
    public class CounterPart
    {
        [ForeignKey("Invoice")]
        public Guid CounterPartId { get; set; }

        // For relationship one-to-one with Transporter table
        public virtual Transporter Transporter { get; set; }

        // For relationship one-to-one with Insurer table
        public virtual Insurer Insurer { get; set; }

        // For relationship one-to-one with Invoice table
        public virtual Invoice Invoice { get; set; }
    }

    public class Transporter
    {
        [ForeignKey("CounterPart")]
        public Guid TransporterId { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }

        // For relationship one-to-one with CounterPart table
        public virtual CounterPart CounterPart { get; set; }
    }

    public class Insurer
    {
        [ForeignKey("CounterPart")]
        public Guid InsurerId { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }

        // For relationship one-to-one with CounterPart table
        public virtual CounterPart CounterPart { get; set; }
    }
}
