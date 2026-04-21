using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aliados
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ViewerForm",
                url: "form/{id}",
                defaults: new { controller = "Viewer", action = "Form", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewerQuery",
                url: "view/{id}",
                defaults: new { controller = "Viewer", action = "Viewer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                  name: "Default",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Security", action = "Login", id = UrlParameter.Optional }
              );
        }
    }
}
