using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.AviaTickets.Controllers
{
    public class GroupOrdersController : Controller
    {
        [HttpGet]
        public ActionResult GroupOrder()
        {
            return PartialView();
        }
    }
}