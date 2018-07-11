using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSG.WEB.API.Infrastructure;

namespace WSG.WEB.API.Models
{
    public class Agent : IAgent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Agent()
        {
            Id = Guid.NewGuid();
        }
    }
}