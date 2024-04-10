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
    public class LecturerController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");

        public async Task<IActionResult> MyCourses()
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var courseCollection = database.GetCollection<Course>("course");

            // Truy vấn các khóa học thuộc về giảng viên này dựa trên LecturerId
            var courseFilter = Builders<Course>.Filter.Eq(x => x.LecturerId, lecturerId);
            var courses = await courseCollection.Find(courseFilter).ToListAsync();

            return View(courses);
        }
        public IActionResult LectureDashboard()
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
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
        public IActionResult AdminLecture()
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturers = table.Find(FilterDefinition<Lecturer>.Empty).ToList();
            return View(lecturers);
        }
        public IActionResult LecturerAdd()
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
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

        public IActionResult Create()
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
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

        [HttpPost]
        public IActionResult Create(Course course)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Course>("course");
            course.Id = Guid.NewGuid().ToString();
            table.InsertOne(course);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturer = table.Find(c => c.Id == id).FirstOrDefault();
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        public ActionResult Edit(Lecturer lecturer)
        {
            if (string.IsNullOrEmpty(lecturer.Id))
            {
                ViewBag.Mgs = "Please provide id";
                return View(lecturer);
            }
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            table.ReplaceOne(c => c.Id == lecturer.Id, lecturer);
            return RedirectToAction("AdminLecture");
        }

        public ActionResult Details(string id)
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturer = table.Find(c => c.Id == id).FirstOrDefault();
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        public ActionResult Delete(string id)
        {
			// session for admin
			var adminId = HttpContext.Session.GetString("AdminId");
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerId = HttpContext.Session.GetString("LecturerId");
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
			var lecturerImage = HttpContext.Session.GetString("LecturerImage");

			// session for student
			var studentId = HttpContext.Session.GetString("StudentId");
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");
			var studentImage = HttpContext.Session.GetString("StudentImage");

			// 
			if (!string.IsNullOrEmpty(adminId) && !string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail) && !string.IsNullOrEmpty(adminImage))
			{
				ViewBag.Id = adminId;
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerId) && !string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail) && !string.IsNullOrEmpty(lecturerImage))
			{
				ViewBag.Id = lecturerId;
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
				ViewBag.Image = lecturerImage;
			}
			else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail) && !string.IsNullOrEmpty(studentImage))
			{
				ViewBag.Id = studentId;
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
				ViewBag.Image = studentImage;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturer = table.Find(c => c.Id == id).FirstOrDefault();
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        public ActionResult Delete(Lecturer lecturer)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            table.DeleteOne(c => c.Id == lecturer.Id);
            return RedirectToAction("AdminLecture");
        }
    }
}
