using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class Remark
    {
        public Remark()
        {
            RemarkId = Guid.NewGuid();
        }
        [Key]
        public Guid RemarkId { get; set; }
        public string RirRemark { get; set; }

        public AviaTicket AviaTicket { get; set; }
        public Guid AviaTicketId { get; set; }
    }
}
