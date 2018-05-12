using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class History
    {
        public History()
        {
            HistoryId = Guid.NewGuid();
        }
        [Key]
        public Guid HistoryId { get; set; }
        public string Action { get; set; }
        public string ActionDate { get; set; }
        public string AirFile { get; set; }
        public string AgentSign { get; set; }
        public string Amount { get; set; }
        public string NationalAmount { get; set; }
        public string NationalCurrency { get; set; }
        public string FormOfPayment { get; set; }

        public Ticket Ticket { get; set; }
        public Guid TicketId { get; set; }
    }
}
