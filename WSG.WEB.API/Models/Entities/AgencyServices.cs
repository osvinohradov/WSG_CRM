using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Услуги агенства
    /// </summary>
    public class AgencyServices : AdditionalInfoBase
    {
        private double percent;
        private double bankPercent;

        public AgencyServices()
        {
        }

        public AgencyServices(double amount, double mpe, string currency, double percent, double bankPercent)
            :base(amount, mpe, currency)
        {
            this.percent = percent;
            this.bankPercent = bankPercent;
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
        public double BankPercent
        {
            get { return this.bankPercent;  }
            set { this.bankPercent = value; }
        }
    }
}