using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WSG.UI.Util;
using WSG.BAL.Infrastructure;
using Ninject;
using Ninject.Web.Mvc;

namespace WSG.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // dependency injection
            NinjectModule aviaInvoceModule = new AviaInvoiceModule();
            NinjectModule serviceModule = new ServiceModule("WSGDataDb");
            var kernel = new StandardKernel(aviaInvoceModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
