using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class NameElement
    {
        public NameElement()
        {
            NameElementId = Guid.NewGuid();
        }
        [Key]
        public Guid NameElementId { get; set; }
        public int Tattoo { get; set; }
        public int ElementNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }

        //public ICollection<Ap> Ap { get; set; }
        //public string Ap { get; set; }
        public ICollection<SsrDocs> SsrDocs { get; set; }
        public ICollection<Ticket> Ticket { get; set; }

        public AviaTicket AviaTicket { get; set; }
        public Guid AviaTicketId { get; set; }
    }
}
