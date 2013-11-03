using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Marketing.Controllers;
using NavigationRoutes;

namespace Marketing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapNavigationRoute<HomeController>("Home", c => c.Index());

            routes.MapNavigationRoute<TerritoriesController>("Admin", c => c.Maintain());

            routes.MapNavigationRoute<UploadReportController>("Reports", c => c.Index())
                .AddChildRoute<UploadReportController>("Upload Report", c => c.Report(null, null))
                .AddChildRoute<UsageReportController>("Usage Report", c => c.Report(null, null));

            routes.MapNavigationRoute<AccountController>("Profile", c => c.Index())
                //.AddChildRoute<AccountController>("Profile", c => c.Profile())
                .AddChildRoute<AccountController>("My Uploads", c => c.MyUploads())
                .AddChildRoute<AccountController>("Logout", c => c.Logout())
                ;
        }
    }
}