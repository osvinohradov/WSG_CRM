using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Использованные таксы
    /// </summary>
    public class UsedRates : AdditionalInfoBase
    {
        public UsedRates()
        {
        }

        public UsedRates(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }
    }
}