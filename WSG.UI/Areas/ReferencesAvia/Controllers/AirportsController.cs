﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia.Controllers
{
    public class AirportsController : Controller
    {
        // GET: ReferencesAvia/Airports
        public ActionResult Index()
        {
            return View("Airports");
        }
    }
}