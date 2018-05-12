using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class Ap
    {
        public Ap()
        {
            ApId = Guid.NewGuid();
        }
        [Key]
        public Guid ApId { get; set; }
        public string Content { get; set; }
    }
}
