using Microsoft.AspNetCore.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (model.Username == "admin" && model.Password == "adminpassword")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (model.Username == "lecturer" && model.Password == "lecturerpassword")
            {
                return RedirectToAction("Index", "Lecturer");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
        }
    }
}
