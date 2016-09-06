using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Task2.Infrastructure;
using Task2.Models;

namespace Task2.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        [Local]
        [HttpGet]
        [ActionName("User-List")]
        public async Task<ActionResult> Index()
        {
            List<User> result = await UserRepository.GetAll();
            return View("Index", result);
        }

        [Local]
        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [Local]
        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> Create(User user)
        {
            await UserRepository.Add(user);
            return RedirectToAction("User-List");
        }

        [Local]
        [HttpGet]
        [ActionName("Delete-User")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await UserRepository.GetById(id);
            if (user == null)
                return RedirectToAction("NotFound");
            return View("Delete", user);
        }

        [Local]
        [HttpPost]
        [ActionName("Delete-User")]
        public async Task<ActionResult> Delete(User user)
        {
            if (user != null)
            {
                await UserRepository.Delete(user);
            }
            return RedirectToAction("User-List");
        }

        [Local]
        [HttpGet]
        [ActionName("Edit-User")]
        public async Task<ActionResult> Edit(int id)
        {
            var user = await UserRepository.GetById(id);
            if (user == null)
                return RedirectToAction("NotFound");
            return View("Edit", user);
        }

        [Local]
        [HttpPost]
        [ActionName("Edit-User")]
        public async Task<ActionResult> Edit(User user)
        {
            if (user != null)
                await UserRepository.Modify(user);
            return RedirectToAction("User-List");
        }
    }
}