using LMS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;
using System.Web;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IMongoCollection<Account> _accountsCollection;

        //public HomeController()
        //{
        //    // Khởi tạo kết nối đến MongoDB
        //    var client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
        //    var database = client.GetDatabase("yourDatabaseName");
        //    _accountsCollection = database.GetCollection<Account>("accoun");
        //}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AdminDashboard()
		{
			return View();
		}

		public IActionResult LectureDashboard()
        {
			return View();
		}
		public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Login(string email, string password)
		{
			// Kiểm tra nullability của email và password
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				TempData["error"] = "Email and password are required";
				return View();
			}

			// Xác định quyền truy cập dựa trên thông tin đăng nhập
			if (email.ToLower() == "nghiapt@fe.edu.vn" && password == "123")
			{
				return RedirectToAction("AdminDashboard");
			}
			else if (email.ToLower() == "nghiapt@fe.edu.vn" && password == "456")
			{
				return RedirectToAction("LectureDashboard");
			}
			else
			{
				TempData["error"] = "Invalid email or password";
				return View();
			}
		}

		public IActionResult Logout()
        {

			// Chuyển hướng đến trang đăng nhập
			return RedirectToAction("Login");
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
