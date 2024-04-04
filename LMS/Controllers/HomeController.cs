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
        public IActionResult IndexLoginAdmin()
        {
            return View();
        }
		public IActionResult IndexLoginLecture()
		{
			return View();
		}
		public IActionResult IndexLoginUser()
		{
			return View();
		}
		//public IActionResult IndexLoginUser()
		//{
		//	return View();
		//}
		//public IActionResult IndexLoginUser()
		//{
		//	return View();
		//}
		//public IActionResult IndexLoginUser()
		//{
		//	return View();
		//}
		//public IActionResult IndexLoginUser()
		//{
		//	return View();
		//}
		//public IActionResult IndexLoginUser()
		//{
		//	return View();
		//}


		// Dashboard
		public IActionResult AdminDashboard()
		{
			return View();
		}

		public IActionResult LectureDashboard()
        {
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

                // Kiểm tra trong bảng admin
                var adminCollection = database.GetCollection<Admin>("admin");
                var adminFilter = Builders<Admin>.Filter.Where(x => x.Email == email && x.Password == password);
                var adminResult = await adminCollection.Find(adminFilter).FirstOrDefaultAsync();
                if (adminResult != null)
                {
                    // Nếu tài khoản là admin, chuyển hướng đến trang index của admin
                    return RedirectToAction("IndexLoginAmin", "Home");
                }

                // Kiểm tra trong bảng lecture nếu không tìm thấy trong bảng admin
                var lecturerCollection = database.GetCollection<Lecturer>("lecturer");
                var lecturerFilter = Builders<Lecturer>.Filter.Where(x => x.Email == email && x.Password == password);
                var lecturerResult = await lecturerCollection.Find(lecturerFilter).FirstOrDefaultAsync();
                if (lecturerResult != null)
                {
                    // Nếu tài khoản là lecture, chuyển hướng đến trang index của lecture
                    return RedirectToAction("IndexLoginLecture", "Home");
                }

                // Kiểm tra trong bảng student nếu không tìm thấy trong bảng admin và lecture
                var studentCollection = database.GetCollection<Student>("student");
                var studentFilter = Builders<Student>.Filter.Where(x => x.Email == email && x.Password == password);
                var studentResult = await studentCollection.Find(studentFilter).FirstOrDefaultAsync();
                if (studentResult != null)
                {
                    // Nếu tài khoản là student, chuyển hướng đến trang index của student
                    return RedirectToAction("IndexLoginUser", "Home");
                }

                // Nếu không tìm thấy tài khoản trong bất kỳ bảng nào, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View(); // Trả về view đăng nhập với thông báo lỗi
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"An error occurred: {ex.Message}");
                return View(); // Trả về view đăng nhập với thông báo lỗi
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
