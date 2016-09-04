using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Task1.CustomConstraints
{
    public class UserBrowserConstraint : IRouteConstraint
    {
        private readonly string _browser;

        public UserBrowserConstraint(string browser)
        {
            _browser = browser;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent != null && httpContext.Request.Browser.Browser.Contains(_browser);
        }
    }
}