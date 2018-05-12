using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia.Controllers
{
    public class ServicesController : Controller
    {
        // GET: ReferencesAvia/Services
        public ActionResult Index()
        {
            return View("Services");
        }
    }
}