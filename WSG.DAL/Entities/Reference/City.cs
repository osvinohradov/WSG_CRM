using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSG.DAL.Entities.Reference
{
    public class City
    {
        public Guid CityId { get; set; }

        public int Code { get; set; }
        public string NameRus { get; set; }
        public string NameUkr { get; set; }
        public string NameEng { get; set; }
    }
}
