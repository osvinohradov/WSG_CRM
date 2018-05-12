using System.Web.Mvc;

namespace WSG.UI.Areas.ReferencesAvia
{
    public class ReferencesAviaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ReferencesAvia";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ReferencesAvia_default",
                "ReferencesAvia/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}