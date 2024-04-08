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
        public IActionResult Course()
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Course>("course");
            var course = table.Find(FilterDefinition<Course>.Empty).ToList();
            return View(course);
        }
		public IActionResult CourseDetail()
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			return View();
		}
		public IActionResult CourseAdd()
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
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
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
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
            return RedirectToAction("Index");
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
			// session for admin
			var adminName = HttpContext.Session.GetString("AdminName");
			var adminRole = HttpContext.Session.GetString("AdminRole");
			var adminEmail = HttpContext.Session.GetString("AdminEmail");
			var adminImage = HttpContext.Session.GetString("AdminImage");

			// session for lecture
			var lecturerName = HttpContext.Session.GetString("LecturerName");
			var lecturerRole = HttpContext.Session.GetString("LecturerRole");
			var lecturerEmail = HttpContext.Session.GetString("LecturerEmail");

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
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
            return RedirectToAction("Index");
        }
		public IActionResult Categories()
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			return View();
		}
		public IActionResult Single(string id)
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Course>("course");
            var filter = Builders<Course>.Filter.Eq(x => x.Id, "aa8cb7c1-fa30-40d2-a8b0-659e37af275a");
            var course = table.Find(filter).FirstOrDefault();

            return View(course);
        }
		public IActionResult Allcourse()
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

			// session for student
			var studentName = HttpContext.Session.GetString("StudentName");
			var studentRole = HttpContext.Session.GetString("StudentRole");
			var studentEmail = HttpContext.Session.GetString("StudentEmail");

			// 
			if (!string.IsNullOrEmpty(adminName) && !string.IsNullOrEmpty(adminRole) && !string.IsNullOrEmpty(adminEmail))
			{
				ViewBag.Name = adminName;
				ViewBag.Role = adminRole;
				ViewBag.Email = adminEmail;
				ViewBag.Image = adminImage;
			}
			else if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(lecturerRole) && !string.IsNullOrEmpty(lecturerEmail))
			{
				ViewBag.Name = lecturerName;
				ViewBag.Role = lecturerRole;
				ViewBag.Email = lecturerEmail;
			}
			else if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentRole) && !string.IsNullOrEmpty(studentEmail))
			{
				ViewBag.Name = studentName;
				ViewBag.Role = studentRole;
				ViewBag.Email = studentEmail;
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid session";
			}
			return View();
		}
	}
}
