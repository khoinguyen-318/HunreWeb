using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HunreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Detail",
                url: "chi-tiet/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "HunreWeb.Controllers" }
            );
            routes.MapRoute(
                name: "Menu",
                url: "menu/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "ViewMenu", id = UrlParameter.Optional },
                namespaces: new[] { "HunreWeb.Controllers" }
            );
            routes.MapRoute(
                name: "Catergory",
                url: "danh-muc/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "ViewCatergory", id = UrlParameter.Optional },
                namespaces: new[] { "HunreWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HunreWeb.Controllers" }
            );
        }
    }
}
