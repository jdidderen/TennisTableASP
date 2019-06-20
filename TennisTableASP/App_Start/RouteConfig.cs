using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TennisTableASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EditList",
                url: "{controller}/Edit/",
                defaults: new {Action = "EditList"}
            );

            routes.MapRoute(
                name: "DeleteList",
                url: "{controller}/Delete/",
                defaults: new {Action = "DeleteList" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Accueil", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
