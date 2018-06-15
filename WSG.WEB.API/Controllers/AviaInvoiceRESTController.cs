using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WSG.WEB.API.Models.Avia;

namespace WSG.WEB.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AviaInvoiceRESTController : ApiController
    {
        List<AviaInvoiceShortViewModel> aviaShortInvoices = new List<AviaInvoiceShortViewModel>();
        public AviaInvoiceRESTController()
        {
            AviaInvoiceShortViewModel[] invoices = new AviaInvoiceShortViewModel[]
           {
                new AviaInvoiceShortViewModel()
                {
                    AviaInvoiceShortId = Guid.NewGuid(),
                    Date = new DateTime(2017, 9, 7),
                    Number = 67533,
                    Returned = true,
                    Void = false,
                    Paid = false,
                    Counterparty = "Фізична особа",
                    GroupInvoiceName = "Групове замовлення",
                    Content = "Enpty content",
                    ProviderName = "Provider",
                    ServiceName = "AirTickets",
                    Sum = 16709.00,
                    MPE = 52.00,
                    Comment = "Kvantum",
                    AgentName = "Anna Tsimbal",
                    ResponsibleAgentName = "Anna Tsimbal",
                    OfferCurrency = "grn",
                    FinalCurrency = "grn",
                    OrganizationName = "WorldService Group",
                    BookingCode = "U7CGW",
                    ReturnDocument = "",
                    DateOfPurchaseFromSupplier = new DateTime(2017, 9, 8),
                    PaymentForm = "Cash",
                    DateOfPayment = new DateTime(),
                    PMCode = "111AB",
                    Processed = true
                },
                new AviaInvoiceShortViewModel()
                {
                    AviaInvoiceShortId = Guid.NewGuid(),
                    Date = new DateTime(2017, 9, 7),
                    Number = 67533,
                    Returned = true,
                    Void = false,
                    Paid = false,
                    Counterparty = "Фізична особа",
                    GroupInvoiceName = "Групове замовлення",
                    Content = "Enpty content",
                    ProviderName = "Provider",
                    ServiceName = "AirTickets",
                    Sum = 16709.00,
                    MPE = 52.00,
                    Comment = "Kvantum",
                    AgentName = "Anna Tsimbal",
                    ResponsibleAgentName = "Anna Tsimbal",
                    OfferCurrency = "grn",
                    FinalCurrency = "grn",
                    OrganizationName = "WorldService Group",
                    BookingCode = "U7CGW",
                    ReturnDocument = "",
                    DateOfPurchaseFromSupplier = new DateTime(2017, 9, 8),
                    PaymentForm = "Cash",
                    DateOfPayment = new DateTime(),
                    PMCode = "111AB",
                    Processed = true
                },
                new AviaInvoiceShortViewModel()
                {
                    AviaInvoiceShortId = Guid.NewGuid(),
                    Date = new DateTime(2017, 9, 7),
                    Number = 67533,
                    Returned = true,
                    Void = false,
                    Paid = false,
                    Counterparty = "Фізична особа",
                    GroupInvoiceName = "Групове замовлення",
                    Content = "Enpty content",
                    ProviderName = "Provider",
                    ServiceName = "AirTickets",
                    Sum = 16709.00,
                    MPE = 52.00,
                    Comment = "Kvantum",
                    AgentName = "Anna Tsimbal",
                    ResponsibleAgentName = "Anna Tsimbal",
                    OfferCurrency = "grn",
                    FinalCurrency = "grn",
                    OrganizationName = "WorldService Group",
                    BookingCode = "U7CGW",
                    ReturnDocument = "",
                    DateOfPurchaseFromSupplier = new DateTime(2017, 9, 8),
                    PaymentForm = "Cash",
                    DateOfPayment = new DateTime(),
                    PMCode = "111AB",
                    Processed = true
                }
           };
            aviaShortInvoices.AddRange(invoices);
        }

        [HttpGet]
        public IEnumerable<AviaInvoiceShortViewModel> GetAllShortInvoices()
        {
            return aviaShortInvoices;
        }

        [HttpGet]
        public AviaInvoiceShortViewModel GetShortInvoice(Guid id)
        {
            return aviaShortInvoices.Find((invoice) => invoice.AviaInvoiceShortId == id);
        }

        [HttpGet]
        public AviaInvoiceShortViewModel GetFullInvoice(Guid id)
        {
            return aviaShortInvoices.Find((invoice) => invoice.AviaInvoiceShortId == id);
        }

        [HttpPost]
        public void CreateInvoice(AviaInvoiceFullViewModel invoice)
        {

        }

        [HttpPut]
        public void UpdateInvoice(AviaInvoiceFullViewModel invoice)
        {

        }

        [HttpDelete]
        public void DeleteInvoice(Guid id)
        {

        }
    }
}
