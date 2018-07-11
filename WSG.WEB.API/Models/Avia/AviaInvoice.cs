using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Infrastructure;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Avia
{
    public class AviaInvoice : InvoiceBase
    {
        private int? ticketsCount;
        private bool? returned;
        private bool? isImplementation;
        private string offerCurrency;
        private string taxesPayment;
        private string bookingCode;
        private string pmCode;
        private bool? @void;

        private AviaDetailInfo aviaDetail;
        private ICollection<FlightInfo> flightsInfo;
        private ICollection<TicketInfo> ticketInfo;

        public AviaInvoice()
        {
        }
        // TODO: added own fields to ctor
        public AviaInvoice(int? number, DateTime? date, string paymentForm, DateTime? paymentDate, double? totalAmount, string client, DateTime? serviceDate, string description,
            bool? paid, IGroupInvoice groupInvoice, string totalCurrency, string provider, string curator, string currencyExchange, DateTime? onDate, string serviceType,
            ICheckingAccount checkingAccount, string comment, IAgent responsibleAgent, IAgent agent, AviaDetailInfo aviaDetailInfo, ICollection<FlightInfo> flightInfos, ICollection<TicketInfo> ticketInfos)
            : base(number, date, paymentForm, paymentDate, totalAmount, client, serviceDate, paid, groupInvoice, totalCurrency, provider, curator, currencyExchange,
                 onDate, serviceType, checkingAccount, comment, responsibleAgent, agent, description)
        {
            this.aviaDetail = aviaDetailInfo;
            this.flightsInfo = flightInfos;
            this.ticketInfo = ticketInfos;
        }

        public int? TicketsCount
        {
            get { return this.ticketsCount; }
            set { this.ticketsCount = value; }
        }
        public bool? Returned
        {
            get { return this.returned; }
            set { this.returned = value; }
        }
        public bool? IsImplementation
        {
            get { return this.isImplementation; }
            set { this.isImplementation = value; }
        }
        public string OfferCurrency
        {
            get { return this.offerCurrency; }
            set { this.offerCurrency = value; }
        }
        public string TaxesPayment
        {
            get { return this.taxesPayment; }
            set { this.taxesPayment = value; }
        }
        public string BookingCode
        {
            get { return this.bookingCode; }
            set { this.bookingCode = value; }
        }
        public string PMCode
        {
            get { return this.pmCode; }
            set { this.pmCode = value; }
        }
        public bool? Void
        {
            get { return this.@void; }
            set { this.@void = value; }
        }

        public AviaDetailInfo AviaDetail
        {
            get { return this.aviaDetail; }
            set { this.aviaDetail = value; }
        }
        public ICollection<FlightInfo> FlightsInfo
        {
            get { return this.flightsInfo; }
            set { this.flightsInfo = value; }
        }
        public ICollection<TicketInfo> TicketInfo
        {
            get { return this.ticketInfo; }
            set { this.ticketInfo = value; }
        }


        // Auto implemented, need to refactoring
        public string Organization { get; set; }
        public string ReturnedDocument { get; set; }
        public DateTime? DateOfPurchaseFromSupplier { get; set; }
        // Обработан
        public bool? Processed { get; set; }
        public double? MPE { get; set; }
    }
}