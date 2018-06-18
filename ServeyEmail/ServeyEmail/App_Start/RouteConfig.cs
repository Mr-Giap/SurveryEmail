using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServeyEmail
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default controller",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Recive Email",
                url: "{controller}/{code}/{number}/{date}",
                defaults: new { controller = "ReciveEmail", action = "Index", code = UrlParameter.Optional, number = UrlParameter.Optional, date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "get date Default",
                url: "{controller}/{action}/{date}",
                defaults: new { controller = "Home", action = "Index", date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
