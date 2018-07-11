using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSG.WEB.API.Models.Entities;

namespace WSG.WEB.API.Models.General
{
    public class AviaDetailInfo
    {

        private string name;
        private string ticketNumber;
        private DateTime? purchaseDate;
        private string description;
        private SupplierCost supplierCost;
        private SupplierCommission supplierCommission;
        private Forfeit forfeit;
        private UsedSupplierRate usedSupplierRate;
        private AdditionalSupplierCommission additionalSupplierComission;
        private UsedRates usedRates;
        private AgencyServices agencyServices;
        private OtherServices otherServices;
        private TotalAmount totalAmount;

        public AviaDetailInfo()
        {
            Id = Guid.NewGuid();
        }
        public AviaDetailInfo(string name, string ticketNumber, DateTime? purchaseDate, string description)
            :this()
        {
            this.name = name;
            this.ticketNumber = ticketNumber;
            this.purchaseDate = purchaseDate;
            this.description = description;
        }
        public AviaDetailInfo(string name, string ticketNumber, DateTime? purchaseDate, string description, SupplierCost supplierCost, SupplierCommission supplierCommission,
            Forfeit forfeit, UsedSupplierRate usedSupplierRate, AdditionalSupplierCommission additionalSupplierComission, UsedRates usedRates, AgencyServices agencyServices,
            OtherServices otherServices, TotalAmount totalAmount)
            : this(name, ticketNumber, purchaseDate, description)
        {
            this.supplierCost = supplierCost;
            this.supplierCommission = supplierCommission;
            this.forfeit = forfeit;
            this.usedSupplierRate = usedSupplierRate;
            this.additionalSupplierComission = additionalSupplierComission;
            this.usedRates = usedRates;
            this.agencyServices = agencyServices;
            this.otherServices = otherServices;
            this.totalAmount = totalAmount;

            
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string TicketNumber
        {
            get { return this.ticketNumber; }
            set { this.ticketNumber = value; }
        }
        public DateTime? PurchaseDate
        {
            get { return this.purchaseDate; }
            set { this.purchaseDate = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public SupplierCost SupplierCost
        {
            get { return this.supplierCost; }
            set { this.supplierCost = value; }
        }
        public SupplierCommission SupplierCommission
        {
            get { return this.supplierCommission; }
            set { this.supplierCommission = value; }
        }
        public Forfeit Forfeit
        {
            get { return this.forfeit; }
            set { this.forfeit = value; }
        }
        public UsedSupplierRate UsedSupplierRate
        {
            get { return this.usedSupplierRate; }
            set { this.usedSupplierRate = value; }
        }
        public AdditionalSupplierCommission AdditionalSupplierCommission
        {
            get { return this.additionalSupplierComission; }
            set { this.additionalSupplierComission = value; }
        }
        public UsedRates UsedRates
        {
            get { return this.usedRates; }
            set { this.usedRates = value; }
        }
        public AgencyServices AgencyServices
        {
            get { return this.agencyServices; }
            set { this.agencyServices = value; }
        }
        public OtherServices OtherServices
        {
            get { return this.otherServices; }
            set { this.otherServices = value; }
        }
        public TotalAmount TotalAmount
        {
            get { return this.totalAmount; }
            set { this.totalAmount = value; }
        }


        public Guid Id { get; set; }
    }
}