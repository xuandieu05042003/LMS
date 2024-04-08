using LMS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;
using System.Web;
using System.Collections;
using MongoDB.Driver.Core.Misc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");

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
		// Index
		public IActionResult IndexNoLogin()
		{
			return View();
		}
        public IActionResult IndexLogin()
        {
            // session for admin
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // session for student
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // 
            if (!string.IsNullOrEmpty(adminName) &&!string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
            {
                ViewBag.Name = adminName;
                ViewBag.Role = adminRole;
                ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
            else if (!string.IsNullOrEmpty(lecturerName) &&!string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
            {
                ViewBag.Name = lecturerName;
                ViewBag.Role = lecturerRole;
                ViewBag.Email = lecturerEmail;
                ViewBag.Image = lecturerImage;
            }
            else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
            {
                ViewBag.Name = studentName;
                ViewBag.Role = studentRole;
                ViewBag.Email = studentEmail;
                ViewBag.Image = studentImage;
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid session";
            }

            return View();
        }

		// Dashboard
		public IActionResult AdminDashboard()
		{
			// session for admin
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}

			return View();
		}

		

		// Login
		public IActionResult Login()
        {
            return View();
        }
		[HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
                var database = client.GetDatabase("universityDtabase");

                var adminCollection = database.GetCollection<Admin>("admin");
                var adminFilter = Builders<Admin>.Filter.Where(x => x.Email == email && x.Password == password);
                var adminResult = await adminCollection.Find(adminFilter).FirstOrDefaultAsync();
                if (adminResult != null)
                {
                    HttpContext.Session.SetString("AdminName", adminResult.Name);
                    HttpContext.Session.SetString("AdminRole", adminResult.Role);
                    HttpContext.Session.SetString("AdminEmail", adminResult.Email);
					HttpContext.Session.SetString("AdminImage", adminResult.Image);
					return RedirectToAction("IndexLogin", "Home");
                }

                var lecturerCollection = database.GetCollection<Lecturer>("lecturer");
                var lecturerFilter = Builders<Lecturer>.Filter.Where(x => x.Email == email && x.Password == password);
                var lecturerResult = await lecturerCollection.Find(lecturerFilter).FirstOrDefaultAsync();
                if (lecturerResult != null)
                {
                    HttpContext.Session.SetString("LecturerName", lecturerResult.Name);
                    HttpContext.Session.SetString("LecturerRole", lecturerResult.Role);
                    HttpContext.Session.SetString("LecturerEmail", lecturerResult.Email);
                    HttpContext.Session.SetString("LecturerImage", lecturerResult.Image);
                    return RedirectToAction("IndexLogin", "Home");
                }

				var studentCollection = database.GetCollection<Student>("student");
				var studentFilter = Builders<Student>.Filter.Where(x => x.Email == email && x.Password == password);
				var studentResult = await studentCollection.Find(studentFilter).FirstOrDefaultAsync();
				if (studentResult != null)
				{
					HttpContext.Session.SetString("StudentName", studentResult.Name);
					HttpContext.Session.SetString("StudentRole", studentResult.Role);
					HttpContext.Session.SetString("StudentEmail", studentResult.Email);
                    HttpContext.Session.SetString("StudentEmail", studentResult.Image);
                    return RedirectToAction("IndexLogin", "Home");
				}

				ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return View();
            }
        }


        public IActionResult Logout()
        {
            //delete session saved
            HttpContext.Session.Clear();

            //Chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login");
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
