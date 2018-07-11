using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WSG.WEB.API.Models;
using WSG.WEB.API.Models.Avia;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AviaController : ApiController
    {
        List<AviaInvoice> aviaInvoices = new List<AviaInvoice>();
        public AviaController()
        {
            aviaInvoices.Add(new AviaInvoice()
            {
                Id = Guid.Parse("c44e3b63-9085-4492-9e93-a401b2621804"),
                Date = new DateTime(2017, 9, 7, 17, 14, 13),
                Number = 67621,
                Returned = false,
                Void = false,
                Paid = true,
                Client = "OPCI",
                GroupInvoice = new AviaGroupInvoice() { Name = "Групове замовлення"},
                Description = "Авіаційний квиток №566-5673066376 для",
                Provider = "ІАТА Україна",
                ServiceType = "AirTickets",
                TotalAmount = 16709.00,
                MPE = 50.00,
                Comment = "galileo = 566-6776657936",
                Agent = new Agent() { Name = "Ігор"},
                ResponsibleAgent = new Agent() { Name = "Ігор"},
                OfferCurrency = "",
                TotalCurrency = "",
                Organization = "",
                BookingCode = "U7CIGW",
                ReturnedDocument = "",
                DateOfPurchaseFromSupplier = new DateTime(2017, 9,7),
                PaymentForm = "Банківський рахунок",
                PaymentDate = new DateTime(2017, 9, 7),
                PMCode = "1111AB",
                Processed = false,
                // Full Invoice Info

                TicketsCount = 1,
                ServiceDate = new DateTime(2017, 9, 27),
                TaxesPayment = "ІАТА УКРАЇНА",
                Curator = "",
                CurrencyExchange = "НБУ",
                OnDate = new DateTime(2017, 9, 7),
                CheckingAccount = new CheckingAccount() { Name = "26001402 Расчетный в АТ..." },
                AviaDetail = new AviaDetailInfo()
                {
                    Name = "Варава Дмитро",
                    TicketNumber = "566-6776657936",
                    PurchaseDate = new DateTime(2017, 9, 7),
                    Description = "Виліт із Kiev/Borispol(KBP, Terminal ) в 27.09.2017 12:00:00\n Приліт в Tbilisi(TBS, Terminal ) в 27.09.2017 15:45:00",
                    SupplierCost = new Models.Entities.SupplierCost()
                    {
                        Amount = 3855,
                        MPE = 0.0,
                        Currency = "грн"
                    },
                    SupplierCommission = new Models.Entities.SupplierCommission()
                    {
                        Percent = 0.0,
                        Amount = 1,
                        MPE = 0.0,
                        Currency = "грн"
                    },
                    Forfeit = new Models.Entities.Forfeit()
                    {
                        Amount = 0.0,
                        MPE = 0.0,
                        Currency = "грн"
                    },
                    UsedSupplierRate = new Models.Entities.UsedSupplierRate()
                    {
                        Tariff = 0,
                        MPE = 0.0,
                        Currency = "грн"
                    },
                    AdditionalSupplierCommission = new Models.Entities.AdditionalSupplierCommission()
                    {
                        Amount = 0,
                        AmountCash = 0,
                        MPE = 0,
                        Currency = "грн"
                    },
                    UsedRates = new Models.Entities.UsedRates()
                    {
                        Amount = 0, 
                        MPE = 0,
                        Currency = "грн"
                    },
                    AgencyServices = new Models.Entities.AgencyServices()
                    {
                        Percent = 0,
                        Amount = 30,
                        BankPercent = 0,
                        MPE = 5.0,
                        Currency = "грн"
                    },
                    OtherServices = new Models.Entities.OtherServices()
                    {
                        Amount = 2712,
                        MPE = 0,
                        Currency = "грн"
                    },
                    TotalAmount = new Models.Entities.TotalAmount()
                    {
                        Amount = 6597,
                        MPE = 5.0,
                        Currency = "грн"
                    }
                },
                FlightsInfo = new List<FlightInfo>()
                {
                    new FlightInfo()
                    {
                        FlightNumber = "PS 515",
                        Place = "",
                        ArrivalPlace = "Kiev/Borispol(KBP, Terminal )",
                        DeparturePlace = "Tbilisi(TBS, Terminal )",
                        ServiceType = "K",
                        ArrivalDateTime = new DateTime(2017, 9, 27, 12, 0, 0),
                        DepartureDateTime = new DateTime(2017, 9, 27, 15, 45, 00)
                    },
                    new FlightInfo()
                    {
                        FlightNumber = "PS 516",
                        Place = "",
                        ArrivalPlace = "Tbilisi(TBS, Terminal )",
                        DeparturePlace = "Kiev/Borispol(KBP, Terminal )",
                        ServiceType = "K",
                        ArrivalDateTime = new DateTime(2017, 9, 30, 16, 35, 0),
                        DepartureDateTime = new DateTime(2017, 9, 30, 18, 35, 00)
                    }
                },
                TicketInfo = new List<TicketInfo>()
                {
                    new TicketInfo()
                    {
                        Name = "Варава Дмитро",
                        TicketNumber = "566-6776657936"
                    }
                }
            });
        }

        [HttpGet]
        public IEnumerable<AviaInvoice> GetAllInvoices()
        {
            ModelDbContext db = new ModelDbContext();
            db.AviaInvoice.AddRange(aviaInvoices);
            // db.SaveChanges();
            return aviaInvoices;
        }
        

        [HttpGet]
        public AviaInvoice GetInvoice(Guid id)
        {
            return aviaInvoices.Find((invoice) => invoice.Id == id);
        }

        [HttpPost]
        public void CreateInvoice(AviaInvoice invoice)
        {
            if(invoice != null)
            {
                ModelDbContext db = new ModelDbContext();
                db.AviaInvoice.Add(invoice);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void UpdateInvoice(AviaInvoice invoice)
        {
            ModelDbContext db = new ModelDbContext();
            db.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteInvoice(Guid id)
        {

        }
    }
}
