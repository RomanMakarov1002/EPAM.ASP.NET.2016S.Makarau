using System.Web.Mvc;
using System.Web.SessionState;

namespace Task2.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}