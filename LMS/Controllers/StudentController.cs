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

        public IActionResult StudentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentAdd(Student student)
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Student>("student");
            student.Id = Guid.NewGuid().ToString();
            table.InsertOne(student);
            //ViewBag.Mgs = "Student has been saved.";
            return RedirectToAction("Index");
        }

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
            return RedirectToAction("Index");
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
    }
}
