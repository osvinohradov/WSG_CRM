using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WSG.WEB.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS Enable
            config.EnableCors();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AviaInvoiceApi",
                routeTemplate: "api/Avia/{action}",
                defaults: new { controller = "Avia" }
            );


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/Main/{action}",
            //    defaults: new { controller = "HomeModule" }
            //);
        }
    }
}
