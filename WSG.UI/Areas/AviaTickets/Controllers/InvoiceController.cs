using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSG.BAL.DTO;
using WSG.BAL.Interfaces;
using WSG.UI.Areas.AviaTickets.Models;
using WSG.UI.Infrastructure;
using WSG.UI.Models;


namespace WSG.UI.Areas.AviaTickets.Controllers
{
    //TODO: Create, Edit, Update
    public class InvoiceController : Controller
    {

        IAviaInvoiceService aviaInvoiceService;

        public InvoiceController(IAviaInvoiceService service)
        {
            this.aviaInvoiceService = service;
        }

        [HttpGet]
        public PartialViewResult Invoice()
        {
            InvoiceModel invoice = new InvoiceModel();
            IEnumerable<AviaInvoiceDTO> aviaInvoiceDTO = this.aviaInvoiceService.GetInvoices();
            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceDTO, AviaInvoiceViewModel>());
            invoice.Invoices = Mapper.Map<IEnumerable<AviaInvoiceDTO>, List<AviaInvoiceViewModel>>(aviaInvoiceDTO);
            return PartialView(invoice);
        }

        [HttpGet]
        public PartialViewResult InvoicePopUp(Guid id)
        {
            InvoiceModel invoice = null;
            if (id != null)
            {
                invoice = new InvoiceModel();
                AviaInvoiceDTO aviaInvoiceDTO = this.aviaInvoiceService.GetInvoice(id);
                IEnumerable<AviaInvoiceFlightDTO> aviaInvoiceFlightsDTO = this.aviaInvoiceService.GetFlights(id);
                Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceDTO, AviaInvoiceViewModel>());
                invoice.Invoice = Mapper.Map<AviaInvoiceDTO, AviaInvoiceViewModel>(aviaInvoiceDTO);
                Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceFlightDTO, AviaInvoiceFlightViewModel>());
                invoice.InvoiceFlight = Mapper.Map<IEnumerable<AviaInvoiceFlightDTO>, List<AviaInvoiceFlightViewModel>>(aviaInvoiceFlightsDTO);
            }
            return PartialView(invoice);
        }
    }
}