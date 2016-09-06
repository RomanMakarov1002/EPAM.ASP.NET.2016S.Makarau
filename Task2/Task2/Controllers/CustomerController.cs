using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;
using Task2.Infrastructure;
using Task2.Models;

namespace Task2.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class CustomerController : BaseController
    {
        // GET: Customer
        [HttpGet]
        [ActionName("User-List")]
        public async Task<ActionResult> Index()
        {
            var result = await UserRepository.GetAll();
            return View("Index", result);
        }

        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> Create(User user)
        {
            await UserRepository.Add(user);
            return RedirectToAction("User-List");
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult Index1()
        {
            var result = UserRepository.GetAll();
            return Json(result);
        }
    }
}