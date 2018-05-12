using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.AviaTickets.Controllers
{
    public class PrintController : Controller
    {
        // GET: AviaTickets/PrintInvoice
        public ActionResult Print(Guid? id)
        {
            return View();
        }

        public ActionResult PrintInvoice()
        {
            return View();
        }

        public ActionResult PrintScore()
        {
            return View();
        }
    }
}