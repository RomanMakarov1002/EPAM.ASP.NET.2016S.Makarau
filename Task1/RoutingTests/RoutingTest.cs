using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Machine.Specifications;
using System.Web;
using System.Web.Routing;
using Moq;
using It = Machine.Specifications.It;
using Task1;

namespace RoutingTests
{
    public class When_static_routing_Home_About
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/About", routes);
            
        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("About", routeData.Values["action"]);
        };        
    }

    public class When_static_routing_EngHome_Index
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/EngHome/Index", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        };
    }

    public class When_Id_for_Compound_route_constraint
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/abc", routes);

        private Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);          

        It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("abc", routeData.Values["id"]);
        };
    }

    public class When_asterisk
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/15/7", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        It should_return = () =>
            Assert.AreEqual(7.ToString(), routeData.Values["catchall"]);
    }

    public class When_asterisk_with_incorrect_id
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        Establish route = () =>
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/3/7", routes);

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        It should_return = () =>
            Assert.AreEqual("3/7", routeData.Values["catchall"]);
    }

    public class When_firefox_browser
    {
        static Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
        static RouteCollection routes = new RouteCollection();
        static RouteData routeData;

        private Establish route = () =>
        {
            Helper.AssertRoutes(httpContextMock, "~/Home/Index/3", routes, "Firefox");
        };

        Because of = () =>
            routeData = routes.GetRouteData(httpContextMock.Object);

        It should_return = () =>
        {
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        };
    }
}
