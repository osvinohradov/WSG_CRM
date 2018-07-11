using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Использованный тариф поставщика
    /// </summary>
    public class UsedSupplierRate : AdditionalInfoBase
    {
        public UsedSupplierRate()
        {
        }

        public UsedSupplierRate(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }

        public double Tariff
        {
            get { return this.Amount; }
            set { this.Amount = value; }
        }

    }
}