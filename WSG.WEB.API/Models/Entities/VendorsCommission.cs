using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Секция - Коммисия поставщика 
    /// </summary>
    public class VendorsCommission : AdditionalInfoBase
    {
        private double percent;

        public VendorsCommission()
        {
        }

        public VendorsCommission(double amount, double mpe, string currency, double percent)
            :base(amount, mpe, currency)
        {
            this.percent = percent;
        }

        public double Percent
        {
            get { return this.percent; }
            set { this.percent = value; }
        }
    }
}