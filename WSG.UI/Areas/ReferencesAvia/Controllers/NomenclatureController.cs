using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia.Controllers
{
    public class NomenclatureController : Controller
    {
        // GET: ReferencesAvia/Nomenclature
        public ActionResult Index()
        {
            return View("Nomenclature");
        }
    }
}