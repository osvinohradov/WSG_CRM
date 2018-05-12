using System.Web.Mvc;

namespace WSG.UI.Areas.AviaTickets
{
    public class AviaTicketsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AviaTickets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AviaTickets_default",
                "AviaTickets/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}