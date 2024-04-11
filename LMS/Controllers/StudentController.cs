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

        public IActionResult Student(string id)
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
            var table = database.GetCollection<Student>("student");
            var student = table.Find(FilterDefinition<Student>.Empty).ToList();
            return View(student);
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
		public IActionResult StudentAdd(Student student, IFormFile Image)
		{
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Student>("student");
			student.Id = Guid.NewGuid().ToString();
			table.InsertOne(student);
			return RedirectToAction("Student");
		}

		[HttpPost]
		public IActionResult Edit(Student student, IFormFile Image)
		{
			if (string.IsNullOrEmpty(student.Id))
			{
				ViewBag.Mgs = "Please provide id";
				return View(student);
			}
			var database = client.GetDatabase("universityDtabase");
			var table = database.GetCollection<Student>("student");

			if (Image != null)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					Image.CopyTo(memoryStream);
					student.Image = Convert.ToBase64String(memoryStream.ToArray());
				}
			}

			table.ReplaceOne(c => c.Id == student.Id, student);
			return RedirectToAction("StudentDashboard");
		}


		public ActionResult Details(String id)
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
    }
}
