using System.Web.Mvc;
using Task4.Infrastructure;
using Task4.Models;

namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var users = PersonRepository.GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePerson()
        {
            var person = new Person();
            if (TryUpdateModel(person, new FormValueProvider(this.ControllerContext)))
            {
                PersonRepository.Add(person);
                return View("Details", person);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateFromQueryString()
        {
            var person = new Person();
            if (TryUpdateModel(person, new QueryStringValueProvider(this.ControllerContext)))
            {
                PersonRepository.Add(person);
                return View("Details", person);
            }
            return View("Create");
        }

        public ActionResult Details(Person person)
        {
            return View(person);
        }
    }
}