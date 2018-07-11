using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSG.WEB.API.Infrastructure;

namespace WSG.WEB.API.Models.Avia
{
    public class AviaGroupInvoice : IGroupInvoice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AviaGroupInvoice()
        {
            Id = Guid.NewGuid();
        }
    }
}