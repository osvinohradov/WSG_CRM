using System.Web.Mvc;

namespace WSG.UI.Areas.RailwayTickets
{
    public class RailwayTicketsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RailwayTickets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RailwayTickets_default",
                "RailwayTickets/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}