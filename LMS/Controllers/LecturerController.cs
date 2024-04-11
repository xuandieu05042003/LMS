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


        public IActionResult LectureDashboard()
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
        public IActionResult AdminLecture()
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
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturers = table.Find(FilterDefinition<Lecturer>.Empty).ToList();
            return View(lecturers);
        }
        public IActionResult LecturerAdd()
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

        public IActionResult Create()
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
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturer = table.Find(c => c.Id == id).FirstOrDefault();
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        [HttpPost]
        public IActionResult Edit(Lecturer lecturer, IFormFile newImage)
        {
            if (string.IsNullOrEmpty(lecturer.Id))
            {
                ViewBag.Mgs = "Please provide id";
                return View(lecturer);
            }

            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");

            if (newImage != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    newImage.CopyTo(memoryStream);
                    lecturer.Image = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            // Cập nhật thông tin giảng viên, bao gồm cả ảnh nếu có
            var filter = Builders<Lecturer>.Filter.Eq(x => x.Id, lecturer.Id);
            var update = Builders<Lecturer>.Update
                .Set(x => x.Name, lecturer.Name)
                .Set(x => x.Email, lecturer.Email)
                .Set(x => x.Password, lecturer.Password)
                .Set(x => x.Image, lecturer.Image);

            table.UpdateOne(filter, update);
            table.ReplaceOne(c => c.Id == lecturer.Id, lecturer);

            return RedirectToAction("LectureDashboard");
        }

        public ActionResult Details(string id)
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