using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Custom route for reports
            routes.MapPageRoute(
             "ReportRoute",                         // Route name
             "ASPX/{reportname}",                // URL
             "~/ASPX/{reportname}.aspx"   // File
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //,
                //namespaces: new string[] { "Purchase.Controllers", "b.Sales.Controllers", "Reports.Controllers" }
             );
        }
    }
}