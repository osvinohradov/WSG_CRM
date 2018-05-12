using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTicketsParser.Entities
{
    public class SoldSeat
    {
        [ForeignKey("Invoice")]
        public Guid SoldSeatId { get; set; }

        // For relationship one-to-one with SoldSeat table
        public virtual Passenger Passenger { get; set; }

        public Price Price { get; set; }
        public int? Id { get; set; }
        public int? CarId { get; set; }
        public int? TosId { get; set; }
        
        // For relationship one-to-one with Invoice table
        public virtual Invoice Invoice { get; set; }
    }
    public class Passenger
    {
        [ForeignKey("SoldSeat")]
        public Guid PassengerId { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        
        // For relationship one-to-one with SoldSeat table
        public virtual SoldSeat SoldSeat { get; set; }
    }
}
