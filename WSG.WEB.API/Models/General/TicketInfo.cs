using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.WEB.API.Models.General
{
    public class TicketInfo
    {
        public string Name { get; set; }
        public string TicketNumber { get; set; }

        public Guid Id { get; set; }
        public TicketInfo()
        {
            Id = Guid.NewGuid();
        }
    }
}