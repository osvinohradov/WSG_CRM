using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSG.DAL.Entities.Reference
{
    public class Counterparty
    {
        public Guid CounterpartyeId { get; set; }
        public int Code { get; set; }

        // General
        public string Individual { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string MainCounterparty { get; set; }
        public string BasicContract { get; set; }
        public bool Resident { get; set; }

        // Other

    }
}
