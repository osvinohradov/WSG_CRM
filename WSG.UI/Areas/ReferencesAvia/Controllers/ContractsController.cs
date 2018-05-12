using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia.Controllers
{
    public class ContractsController : Controller
    {
        // GET: ReferencesAvia/Contracts
        public ActionResult Index()
        {
            return View("Contracts");
        }
    }
}