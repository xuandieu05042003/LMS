using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using LMS.Models;
using MongoDB.Bson;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace LMS.Controllers
{
	public class CourseController : Controller
	{
		private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
        public async Task<IActionResult> MyCourses()
        {
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
            var courseCollection = database.GetCollection<Course>("course");

            // Truy vấn các khóa học thuộc về giảng viên này dựa trên LecturerId
            var courseFilter = Builders<Course>.Filter.Eq(x => x.LecturerId, lecturerId);
            var courses = await courseCollection.Find(courseFilter).ToListAsync();

            return View(courses);
        }
        public IActionResult Course()
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var course = table.Find(FilterDefinition<Course>.Empty).ToList();
			return View(course);
		}
		public IActionResult CourseDetail()
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            return View();
		}
		public IActionResult CourseAdd(string id)
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            return View();
		}
		[HttpPost]
		public IActionResult CourseAdd(Course course)
		{
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			course.Id = Guid.NewGuid().ToString();
			table.InsertOne(course);
			return RedirectToAction("MyCourses");
		}

		public ActionResult Edit(string id)
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var course = table.Find(c => c.Id == id).FirstOrDefault();
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (string.IsNullOrEmpty(course.Id))
			{
				ViewBag.Mgs = "Please provide id";
				return View(course);
			}
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			table.ReplaceOne(c => c.Id == course.Id, course);
			return RedirectToAction("MyCourses");
		}

		public ActionResult Details(String id)
		{
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var course = table.Find(c => c.Id == id).FirstOrDefault();
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		public ActionResult Delete(string id)
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var course = table.Find(c => c.Id == id).FirstOrDefault();
			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		[HttpPost]
		public ActionResult Delete(Course course)
		{
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			table.DeleteOne(c => c.Id == course.Id);
			return RedirectToAction("MyCourses");
		}
		public IActionResult Categories()
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            return View();
		}
		public IActionResult Single(string id)
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var lecturertable = database.GetCollection<Lecturer>("lecturer");
			var course = table.Find(c => c.Id == id).FirstOrDefault();
			if (course == null)
			{
				return NotFound();
			}
			var lecturer = lecturertable.Find(l => l.Id == course.LecturerId).FirstOrDefault();
			if (lecturer != null)
			{
				ViewBag.LecturerImage = lecturer.Image;
			}

			return View(course);
		}
		public IActionResult Allcourse()
		{
            // Session for admin
            var adminId = HttpContext.Session.GetString("AdminId");
            var adminName = HttpContext.Session.GetString("AdminName");
            var adminRole = HttpContext.Session.GetString("AdminRole");
            var adminEmail = HttpContext.Session.GetString("AdminEmail");
            var adminImage = HttpContext.Session.GetString("AdminImage");

            // Session for lecturer
            var lecturerId = HttpContext.Session.GetString("LecturerId");
            var lecturerName = HttpContext.Session.GetString("LecturerName");
            var lecturerRole = HttpContext.Session.GetString("LecturerRole");
            var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");
            var lecturerImage = HttpContext.Session.GetString("LecturerImage");

            // Session for student
            var studentId = HttpContext.Session.GetString("StudentId");
            var studentName = HttpContext.Session.GetString("StudentName");
            var studentRole = HttpContext.Session.GetString("StudentRole");
            var studentEmail = HttpContext.Session.GetString("StudentEmail");
            var studentImage = HttpContext.Session.GetString("StudentImage");

            // Check and set ViewBag
            if (!string.IsNullOrEmpty(adminId))
            {
                ViewBag.Id = adminId;
                ViewBag.Name = adminName ?? "";
                ViewBag.Role = adminRole ?? "";
                ViewBag.Email = adminEmail ?? "";
                ViewBag.Image = adminImage ?? "";
            }
            else if (!string.IsNullOrEmpty(lecturerId))
            {
                ViewBag.Id = lecturerId;
                ViewBag.Name = lecturerName ?? "";
                ViewBag.Role = lecturerRole ?? "";
                ViewBag.Email = lecturerEmail ?? "";
                ViewBag.Image = lecturerImage ?? "";
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                ViewBag.Id = studentId;
                ViewBag.Name = studentName ?? "";
                ViewBag.Role = studentRole ?? "";
                ViewBag.Email = studentEmail ?? "";
                ViewBag.Image = studentImage ?? "";
            }
            else
            {
                // Set ViewBag to null
                ViewBag.Id = null;
                ViewBag.Name = null;
                ViewBag.Role = null;
                ViewBag.Email = null;
                ViewBag.Image = null;
            }
            var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Course>("course");
			var courses = table.Find(FilterDefinition<Course>.Empty).ToList();
			return View(courses);
		}
	}
}