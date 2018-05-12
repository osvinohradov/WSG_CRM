using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class AviaTicket
    {
        public AviaTicket()
        {
            AviaTicketId = Guid.NewGuid();
        }
        [Key]
        public Guid AviaTicketId { get; set; }
        public string RecordLocator { get; set; }
        public string CreationDate { get; set; }
        public string OfficeidBooking { get; set; }
        public string AgentSignBooking { get; set; }
        public string ChangeDate { get; set; }

        public ICollection<string> LastTransactionDate { get; set; }
        public ICollection<NameElement> NameElement { get; set; }
        public ICollection<Remark> Remarks { get; set; }

    }
}
