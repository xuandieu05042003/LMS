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
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            var student = table.Find(FilterDefinition<Student>.Empty).ToList();
            return View(student);
        }

        [HttpPost]
		public ActionResult Edit(string id)
		{
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
            return RedirectToAction("Index");
        }
        public IActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            var user = table.AsQueryable<Student>().FirstOrDefault(s => s.Email == student.Email && s.Password == student.Password);
            if (user != null)
            {
                // Authentication successful, redirect to student dashboard or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Loginfail = "Invalid username or password";
                return View();
            }
        }
        public IActionResult StudentRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentRegister(Student student)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            student.Id = Guid.NewGuid().ToString();
            table.InsertOne(student);
            //ViewBag.Mgs = "Student has been saved.";
            return RedirectToAction("Login", "Home");
        }
    }
}
