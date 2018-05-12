using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Models.Avia
{
    [Table("AviaInvoice")]
    public class AviaInvoice
    {
        public AviaInvoice()
        {
            InvoiceId = Guid.NewGuid();
        }
        [Key]
        public Guid InvoiceId { get; set; }
        public virtual int Number { get; set; }
        public virtual DateTime? LastTransactionDate { get; set; }  // DateTime
        public virtual string PaymentForm { get; set; }
        public virtual DateTime? PaymentDate { get; set; } // DateTime
        public virtual int TicketsCount { get; set; }
        public virtual double Client { get; set; }
        public virtual DateTime? ServiceDate { get; set; } // DateTime
        public virtual bool Implementation { get; set; }
        public virtual bool Return { get; set; }
        public virtual bool Paid { get; set; }
        public virtual double CurrencyOffer { get; set; }
        public virtual double TotalCurrency { get; set; }
        public virtual string Provider { get; set; }
        public virtual string PaymentTax { get; set; }
        public virtual string Curator { get; set; }
        public virtual string BookingCode { get; set; }
        public virtual string CurrencyExchange { get; set; }
        public virtual string OnDate { get; set; }
        public virtual string ServiceType { get; set; }
        public virtual string CheckingAcount { get; set; }
        public virtual string Responsible { get; set; }
        public virtual string Agent { get; set; }
        public virtual string PMCode { get; set; }
        public virtual string FullName { get; set; }
        public virtual string TicketNumber { get; set; }
        public virtual DateTime? PurchaseDate { get; set; }  // DateTime
        public virtual double ProviderAmountSum { get; set; }
        public virtual double ProviderAmountMPE { get; set; }
        public virtual string ProviderAmountCurrency { get; set; }
        public virtual string ProviderCommissionPer { get; set; }
        public virtual string ProviderCommissionSum { get; set; }
        public virtual string ProviderCommissionMPE { get; set; }
        public virtual string ProviderCommissionCurrency { get; set; }
        public virtual string ForfeitSum { get; set; }
        public virtual string ForfeitMPE { get; set; }
        public virtual string ForfeitCurrency { get; set; }
        public virtual string ProviderTax { get; set; }
        public virtual string ProviderTaxMPE { get; set; }
        public virtual string ProviderTaxCurrency { get; set; }
        public virtual string ProviderAdditionalCommissionSum1 { get; set; }
        public virtual string ProviderAdditionalCommissionSum2 { get; set; }
        public virtual string ProviderAdditionalCommissionMPE { get; set; }
        public virtual string ProviderAdditionalCommissionCurrency { get; set; }
        public virtual string UsedTaxSum { get; set; }
        public virtual string UsedTaxMPE { get; set; }
        public virtual string UsedTaxCurrency { get; set; }
        public virtual string AgentServicePer { get; set; }
        public virtual string AgentServiceSum { get; set; }
        public virtual string AgentServiceBankPer { get; set; }
        public virtual string AgentServiceMPE { get; set; }
        public virtual string AgentServiceCurrency { get; set; }
        public virtual double OtherServiceSum { get; set; }
        public virtual double OtherServiceMPE { get; set; }
        public virtual string OtheServiceCurrency { get; set; }
        public virtual double TotalSum { get; set; }
        public virtual double TotalMPE { get; set; }
        public virtual string AdditionalInformation { get; set; }

        public virtual ICollection<AviaInvoiceTicket> Tickets { get; set; }
        public virtual ICollection<AviaInvoiceFlight> Flights { get; set; }
    }
}
