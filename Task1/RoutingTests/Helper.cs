using System.Web;
using System.Web.Routing;
using Moq;

namespace RoutingTests
{
    public static class Helper
    {
        public static void AssertRoutes(Mock<HttpContextBase> httpContextMock, string url, RouteCollection routes)
        {
            Task1.RouteConfig.RegisterRoutes(routes);
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);        
        }

        public static void AssertRoutes(Mock<HttpContextBase> httpContextMock, string url, RouteCollection routes, string browser)
        {
            Task1.RouteConfig.RegisterRoutes(routes);
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            httpContextMock.Setup(c => c.Request.Browser.Browser).Returns(browser);
        }
    }
}
