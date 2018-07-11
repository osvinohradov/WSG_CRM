using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.WEB.API.Infrastructure
{
    public interface IInvoice
    {
        int? Number { get; set; }
        DateTime? Date { get; set; }
        string PaymentForm { get; set; }
        DateTime? PaymentDate { get; set; }
        double? TotalAmount { get; set; }
        string Client { get; set; }
        DateTime? ServiceDate { get; set; }
        bool? Paid { get; set; }
        IGroupInvoice GroupInvoice { get; set; }
        string TotalCurrency { get; set; }
        string Provider { get; set; }
        string Curator { get; set; }
        string CurrencyExchange { get; set; }
        DateTime? OnDate { get; set; }
        string ServiceType { get; set; }
        ICheckingAccount CheckingAccount { get; set; }
        string Comment { get; set; }
        IAgent ResponsibleAgent { get; set; }
        IAgent Agent { get; set; }
    }
}