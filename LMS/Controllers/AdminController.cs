﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using LMS.Models;
using MongoDB.Bson;

namespace LMS.Controllers
{
    public class AdminController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
		
        public IActionResult AdminDashboard()
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
        public IActionResult Index()
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
            var table = database.GetCollection<Admin>("admin");
            var admins = table.Find(FilterDefinition<Admin>.Empty).ToList();
			ViewBag.userCount = admins.Count;
            return View(admins);
        }

        public IActionResult AddAccount()
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
        public IActionResult AddAccount(Admin admin, IFormFile Image)
        {
            var database = client.GetDatabase("universityDtabase");

            string collectionName = "admin";
            if (admin.Role == "Lecturer")
            {
                collectionName = "lecturer";
            }
            else if (admin.Role == "Student")
            {
                collectionName = "student";
            }

            var table = database.GetCollection<Admin>(collectionName);
            admin.Id = Guid.NewGuid().ToString();

            if (Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    admin.Image = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            else
            {
                admin.Image = "";
            }

            table.InsertOne(admin);

            // Chuyển hướng đến trang index của phần tạo tài khoản tương ứng
            if (collectionName == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (collectionName == "lecturer")
            {
                return RedirectToAction("AdminLecture", "Lecturer");
            }
            else if (collectionName == "student")
            {
                return RedirectToAction("Student", "Student");
            }
            else
            {
                // Trong trường hợp không thể xác định được loại tài khoản, chuyển hướng về trang Index của Admin
                return RedirectToAction("Index", "Admin");
            }
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
            var table = database.GetCollection<Admin>("admin");
            var admin = table.Find(c => c.Id == id).FirstOrDefault();
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit(Admin admin, IFormFile Image)
        {
            if (string.IsNullOrEmpty(admin.Id))
            {
                ViewBag.Mgs = "Please provide id";
                return View(admin);
            }
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Admin>("admin");

            if (Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    admin.Image = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            table.ReplaceOne(c => c.Id == admin.Id, admin);
            return RedirectToAction("Index");
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
            var table = database.GetCollection<Admin>("admin");
            var admin = table.Find(c => c.Id == id).FirstOrDefault();
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
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
            var table = database.GetCollection<Admin>("admin");
            var admin = table.Find(c => c.Id == id).FirstOrDefault();
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        [HttpPost]
        public ActionResult Delete(Admin admin)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Admin>("admin");
            table.DeleteOne(c => c.Id == admin.Id);
            return RedirectToAction("Index");
        }
    }
}
