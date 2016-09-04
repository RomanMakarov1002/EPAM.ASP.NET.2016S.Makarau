using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Task1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("FirefoxRoute", "{controller}/{action}/{id}",
                 new { id = UrlParameter.Optional },
                 new { customConstraint = new CustomConstraints.UserBrowserConstraint("Firefox") },
                 new[] { "Task1.Controllers" });

            routes.MapRoute("StaticControllerAndIndex", "Home/About",
                new { controller = "Home", action = "About" },
                new[] {"Task1.Controllers"});

            routes.MapRoute("StaticRoute", "Eng{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "CustomLibrary.Controllers" });

            routes.MapRoute("CompoundRoute", "{controller}/{action}/{id}",
                new { controller = "Home", action = "About" },
                new { id = new CompoundRouteConstraint(new IRouteConstraint[]
                    { new AlphaRouteConstraint(), new MinLengthRouteConstraint(3) })},
                new[] { "Task1.Controllers" });

            routes.MapRoute("CatchallRoute", "{controller}/{action}/{id}/{*catchall}",
                 new { controller = "Home", id = UrlParameter.Optional },
                 new { controller = "^H.*", action = "Index", id = new RangeRouteConstraint(10, 20) },
                 new [] { "CustomLibrary.Controllers" });

            routes.MapRoute("CatchallRouteIncorrectId", "{controller}/{action}/{*catchall}",
                 new { controller = "Home" },
                 new { controller = "^H.*", action = "Index" },
                 new[] { "Task1.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Task1.Controllers" }
            );
        }
    }
}
