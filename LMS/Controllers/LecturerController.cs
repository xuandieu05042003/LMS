using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMS.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LecturerController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");

        public IActionResult Index()
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Lecturer>("lecturer");
            var lecturers = table.Find(FilterDefinition<Lecturer>.Empty).ToList();
            return View(lecturers);
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Course course)
        //{
        //    var database = client.GetDatabase("universityDtabase");
        //    var table = database.GetCollection<Course>("course");
        //    course.Id = Guid.NewGuid().ToString();
        //    table.InsertOne(course);
        //    return RedirectToAction("Index");
        //}

        public ActionResult Edit(string id)
        {
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
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
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
            return RedirectToAction("Index");
        }
    }
}
