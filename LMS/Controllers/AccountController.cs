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
            if (model.Username.Equals("admin") && model.Password.Equals("adminpassword"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (model.Username.Equals("lecturer") && model.Password.Equals("lecturerpassword"))
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
