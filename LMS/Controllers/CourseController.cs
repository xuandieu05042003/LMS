using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using LMS.Models;

namespace LMS.Controllers
{
    public class CourseController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
        public IActionResult Course()
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Course>("course");
            var course = table.Find(FilterDefinition<Course>.Empty).ToList();
            return View(course);
        }
		public IActionResult CourseDetail()
		{
            return View();
		}
		public IActionResult CourseAdd()
		{
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
			return View();
		}
		public IActionResult Single()
		{
			return View();
		}
	}
}
