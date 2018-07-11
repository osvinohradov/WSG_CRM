using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Другие услуги
    /// </summary>
    public class OtherServices : AdditionalInfoBase
    {
        public OtherServices()
        {
        }

        public OtherServices(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }
    }
}