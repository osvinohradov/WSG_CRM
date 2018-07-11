using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Всего
    /// </summary>
    public class TotalAmount : AdditionalInfoBase
    {
        public TotalAmount()
        {
        }

        public TotalAmount(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }
    }
}