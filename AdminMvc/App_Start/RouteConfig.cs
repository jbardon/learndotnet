using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
             * Automapping urls to controllers
             * ex:
             * with controller = Home and action = Sample
             *   - Controllers/HomeController has Sample method
             *   - Views/Home/Sample.cshtml
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Sample", id = UrlParameter.Optional }
            );
        }
    }
}
