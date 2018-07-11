using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Infrastructure;

namespace WSG.WEB.API.Models.General
{
    public abstract class InvoiceBase : IInvoice
    {
        private Guid id;
        private int? number;
        private DateTime? date;
        private string paymentForm;
        private DateTime? paymentDate;
        private double? totalAmount;
        private string client;
        private DateTime? serviceDate;
        private bool? paid;
        private IGroupInvoice groupInvoice;
        private string totalCurrency;
        private string provider;
        private string curator;
        private string currencyExchange;
        private DateTime? onDate;
        private string serviceType;
        private ICheckingAccount checkingAccount;
        private string comment;
        private IAgent responsibleAgent;
        private IAgent agent;
        private string description;

        public InvoiceBase()
        {
            this.id = Guid.NewGuid();
        }

        protected InvoiceBase(int? number, DateTime? date, string paymentForm, DateTime? paymentDate, double? totalAmount, string client, DateTime? serviceDate,
            bool? paid, IGroupInvoice groupInvoice, string totalCurrency, string provider, string curator, string currencyExchange, DateTime? onDate, string serviceType,
            ICheckingAccount checkingAccount, string comment, IAgent responsibleAgent, IAgent agent, string description)
            : this()
        {
            this.number = number;
            this.date = date;
            this.paymentForm = paymentForm;
            this.paymentDate = paymentDate;
            this.totalAmount = totalAmount;
            this.client = client;
            this.serviceDate = serviceDate;
            this.paid = paid;
            this.groupInvoice = groupInvoice;
            this.totalCurrency = totalCurrency;
            this.provider = provider;
            this.curator = curator;
            this.currencyExchange = currencyExchange;
            this.onDate = OnDate;
            this.serviceType = serviceType;
            this.checkingAccount = checkingAccount;
            this.comment = comment;
            this.responsibleAgent = responsibleAgent;
            this.agent = agent;
            this.description = description;
        }

        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int? Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
        public DateTime? Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public string PaymentForm
        {
            get
            {
                return this.paymentForm;
            }
            set
            {
                this.paymentForm = value;
            }
        }
        public DateTime? PaymentDate
        {
            get
            {
                return this.paymentDate;
            }
            set
            {
                this.paymentDate = value;
            }
        }
        public double? TotalAmount
        {
            get
            {
                return this.totalAmount;
            }
            set
            {
                this.totalAmount = value;
            }
        }
        public string Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
            }
        }
        public DateTime? ServiceDate
        {
            get
            {
                return this.serviceDate;
            }
            set
            {
                this.serviceDate = value;
            }
        }
        public bool? Paid
        {
            get
            {
                return this.paid;
            }
            set
            {
                this.paid = value;
            }
        }
        public IGroupInvoice GroupInvoice
        {
            get
            {
                return this.groupInvoice;
            }
            set
            {
                this.groupInvoice = value;
            }
        }
        public string TotalCurrency
        {
            get
            {
                return this.totalCurrency;
            }
            set
            {
                this.totalCurrency = value;
            }
        }
        public string Provider
        {
            get
            {
                return this.provider;
            }
            set
            {
                this.provider = value;
            }
        }
        public string Curator
        {
            get
            {
                return this.curator;
            }
            set
            {
                this.curator = value;
            }
        }
        public string CurrencyExchange
        {
            get
            {
                return this.currencyExchange;
            }
            set
            {
                this.currencyExchange = value;
            }
        }
        public DateTime? OnDate
        {
            get
            {
                return this.onDate;
            }
            set
            {
                this.onDate = value;
            }
        }
        public string ServiceType
        {
            get
            {
                return this.serviceType;
            }
            set
            {
                this.serviceType = value;
            }
        }
        public ICheckingAccount CheckingAccount
        {
            get
            {
                return this.checkingAccount;
            }
            set
            {
                this.checkingAccount = value;
            }
        }
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
        public IAgent ResponsibleAgent
        {
            get { return this.responsibleAgent; }
            set { this.responsibleAgent = value; }
        }
        public IAgent Agent
        {
            get { return this.agent; }
            set { this.agent = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}