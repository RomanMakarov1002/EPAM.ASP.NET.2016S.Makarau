using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTask3.Infrastructure;

namespace AspTask3.Controllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        public ActionResult Index2()
        {
            return View(new CustomDataView());
        }

        public ActionResult Index()
        {
            string[] str = new[] {"Apple, Orange, Cherry"};
            return View(str);
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Person()
        {
            return View("Person");
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var faction = CustomRepository.GetSide();
            return PartialView("Header", faction);
        }

        [HttpPost]
        public ActionResult Footer(string value)
        {
            if (CustomRepository.GetSide() == "white")
                if (value == "Yes")
                    CustomRepository.ChangeSideToBlack();
            return RedirectToAction("Person", "Custom");
        }
    }
}