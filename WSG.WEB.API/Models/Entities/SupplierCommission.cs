using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    public class SupplierCommission : AdditionalInfoBase
    {
        private double percent;

        public SupplierCommission()
        {
        }

        public SupplierCommission(double amount, double mpe, string currency, double percent)
            : base(amount, mpe, currency)
        {
            this.percent = percent;
        }

        public double Percent
        {
            get
            {
                return this.percent;
            }
            set
            {
                this.percent = value;
            }
        }
    }
}