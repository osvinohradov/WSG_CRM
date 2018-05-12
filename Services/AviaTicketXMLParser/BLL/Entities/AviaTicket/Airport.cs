using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class Airport
    {
        public Airport()
        {
            AirportId = Guid.NewGuid();
        }
        [Key]
        public Guid AirportId { get; set; }
        public string Code { get; set; }
        public string AmaName { get; set; }
    }
}
