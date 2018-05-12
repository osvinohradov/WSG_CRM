using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSG.BAL.DTO;
using WSG.BAL.Interfaces;
using WSG.UI.Models;

namespace WSG.UI.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult IndexAvia()
        //{
        //    IEnumerable<AviaInvoiceDTO> aviaInvoiceDTO = this.aviaInvoiceService.GetInvoices();
        //    Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceDTO, AviaInvoiceViewModel>());
        //    var invoices = Mapper.Map<IEnumerable<AviaInvoiceDTO>, List<AviaInvoiceViewModel>>(aviaInvoiceDTO);
        //    ViewBag.A = invoices;
        //    return View();
        //}

        //    public ActionResult MakeOrder(int? id)
        //    {
        //        try
        //        {
        //            PhoneDTO phone = orderService.GetPhone(id);
        //            Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, OrderViewModel>()
        //                .ForMember("PhoneId", opt => opt.MapFrom(src => src.Id)));
        //            var order = Mapper.Map<PhoneDTO, OrderViewModel>(phone);
        //            return View(order);
        //        }
        //        catch (ValidationException ex)
        //        {
        //            return Content(ex.Message);
        //        }
        //    }
        //    [HttpPost]
        //    public ActionResult MakeOrder(OrderViewModel order)
        //    {
        //        try
        //        {
        //            Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
        //            var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
        //            orderService.MakeOrder(orderDto);
        //            return Content("<h2>Ваш заказ успешно оформлен</h2>");
        //        }
        //        catch (ValidationException ex)
        //        {
        //            ModelState.AddModelError(ex.Property, ex.Message);
        //        }
        //        return View(order);
        //    }
        //    protected override void Dispose(bool disposing)
        //    {
        //        orderService.Dispose();
        //        base.Dispose(disposing);
        //    }
        //}

        public ActionResult Create()
        {
            return View();
        }
    }
}