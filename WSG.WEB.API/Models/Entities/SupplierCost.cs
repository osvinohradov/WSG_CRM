using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Стоимость поставщика
    /// </summary>
    public class SupplierCost : AdditionalInfoBase
    {
        public SupplierCost()
        {
        }

        public SupplierCost(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }
    }
}