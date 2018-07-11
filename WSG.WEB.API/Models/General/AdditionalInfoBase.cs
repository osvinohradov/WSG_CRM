using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Infrastructure;

namespace WSG.WEB.API.Models.General
{
    public abstract class AdditionalInfoBase : IAdditionalInfo
    {
        private double amount;
        private double mpe;
        private string currency;

        public AdditionalInfoBase()
        {

        }

        public AdditionalInfoBase(double amount, double mpe, string currency)
        {
            this.amount = amount;
            this.mpe = mpe;
            this.currency = currency;
        }

        public virtual double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
        public virtual double MPE
        {
            get
            {
                return this.mpe;
            }
            set
            {
                this.mpe = value;
            }
        }
        public virtual string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }
    }
}