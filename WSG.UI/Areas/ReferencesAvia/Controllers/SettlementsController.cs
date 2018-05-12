using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia.Controllers
{
    public class SettlementsController : Controller
    {
        // населенные пункты
        // GET: ReferencesAvia/Settlements
        public ActionResult Index()
        {
            return View("Settlements");
        }
    }
}