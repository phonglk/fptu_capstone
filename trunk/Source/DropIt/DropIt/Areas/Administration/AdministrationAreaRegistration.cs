using System.Web.Mvc;

namespace DropIt.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Administration_default",
               url: "Administration/{controller}/{action}/{id}",
               defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "DropIt.Areas.Administration.Controllers" }
               );
            context.MapRoute(
               name: "Administration_Event",
               url: "Administration/Event/Index/{EventStatus}",
               defaults: new { controller = "Event", action = "Index", EventStatus = -1 },
               namespaces: new[] { "DropIt.Areas.Administration.Controllers" }
               );
        }
    }
}
