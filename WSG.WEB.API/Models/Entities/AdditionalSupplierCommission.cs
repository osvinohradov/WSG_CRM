using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Дополнительная коммисия поставщика
    /// </summary>
    public class AdditionalSupplierCommission : AdditionalInfoBase
    {
        private double amountCash;

        public AdditionalSupplierCommission()
        {
        }

        public AdditionalSupplierCommission(double amount, double mpe, string currency, double amountCash)
            :base(amount, mpe, currency)
        {
            this.amountCash = amountCash;
        }

        public double AmountCash
        {
            get
            {
                return this.amountCash;
            }
            set
            {
                this.amountCash = value;
            }
        }
    }
}