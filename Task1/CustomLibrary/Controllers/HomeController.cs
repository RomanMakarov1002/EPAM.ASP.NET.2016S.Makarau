using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomLibrary.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index(string catchall)
        //{
        //    ViewBag.catchall = catchall + HttpContext.Request.Browser.Browser;
        //    return View("Index1");
        //}
        public JsonResult Index(string catchall)
        {
            return Json(catchall + HttpContext.Request.Browser.Browser);
        }
    }
}
