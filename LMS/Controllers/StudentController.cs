using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Models;
using MongoDB.Driver;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");

        public IActionResult Student()
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
            var table = database.GetCollection<Student>("student");
            var student = table.Find(FilterDefinition<Student>.Empty).ToList();
            return View(student);
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
            var table = database.GetCollection<Student>("student");
            var student = table.Find(c => c.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

		public IActionResult StudentAdd()
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
		public IActionResult StudentAdd(Student student, IFormFile Image)
		{
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Student>("student");
			student.Id = Guid.NewGuid().ToString();
			table.InsertOne(student);
			return RedirectToAction("Student");
		}


		[HttpPost]
        public ActionResult Edit(Student student)
        {
            if (string.IsNullOrEmpty(student.Id))
            {
                ViewBag.Mgs = "Please provide id";
                return View(student);
            }
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            table.ReplaceOne(c => c.Id == student.Id, student);
            return RedirectToAction("Student");
        }


        public ActionResult Details(String id)
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
            var table = database.GetCollection<Student>("student");
            var student = table.Find(c => c.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
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
            var table = database.GetCollection<Student>("student");
            var student = table.Find(c => c.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            table.DeleteOne(c => c.Id == student.Id);
            return RedirectToAction("Student");
        }
        public IActionResult StudentDashboard()
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
