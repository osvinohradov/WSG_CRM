using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.WEB.API.Models.Avia
{
    public class AviaInvoiceShortViewModel
    {
        public Guid AviaInvoiceShortId { get; set; }
        public DateTime Date { get; set; }
        public long Number { get; set; }
        public bool Returned { get; set; }
        public bool Void { get; set; }
        public bool Paid { get; set; }
        public string Counterparty { get; set; }
        public string GroupInvoiceName { get; set; }
        public string ServiceName { get; set; }
        public string Content { get; set; }
        public string ProviderName { get; set; }
        public double Sum { get; set; }
        public double MPE { get; set; }
        public string Comment { get; set; }
        public string AgentName { get; set; }
        public string ResponsibleAgentName { get; set; }
        public string OfferCurrency { get; set; }
        public string FinalCurrency { get; set; }
        public string OrganizationName { get; set; }
        public string BookingCode { get; set; }
        public string ReturnDocument { get; set; }
        public DateTime DateOfPurchaseFromSupplier { get; set; }
        public string PaymentForm { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string PMCode { get; set; }
        public bool Processed { get; set; }
    }
}