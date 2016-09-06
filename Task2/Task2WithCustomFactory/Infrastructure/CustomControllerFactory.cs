using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Task2.Controllers;

namespace Task2WithCustomFactory.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "Admin":
                    targetType = typeof (AdminController);
                    break;
                case "Home":
                    targetType = typeof (HomeController);
                    break;
                case "Customer":
                    targetType = typeof (CustomerController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Home";
                    requestContext.RouteData.Values["action"] = "Index";
                    targetType = typeof (HomeController);
                    break;
            }
            return targetType == null ? null : (IController) DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            if (controllerName.Contains("Home"))
                return SessionStateBehavior.Disabled;
            else
                return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}