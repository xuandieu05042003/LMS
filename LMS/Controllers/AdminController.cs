using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using LMS.Models;

namespace LMS.Controllers
{
    public class AdminController : Controller
    {
        private MongoClient client = new MongoClient("mongodb+srv://dieunxbd00122:dieu050403@lms.f19fpne.mongodb.net/");
        public IActionResult Index()
        {
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Admin>("admin");
            var admin = table.Find(FilterDefinition<Admin>.Empty).ToList();
            return View(admin);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            var database = client.GetDatabase("universityDtabase");

            string collectionName = "admin";
            if (admin.Role == "Lecturer")
            {
                collectionName = "lecturer";
            }

            var table = database.GetCollection<Admin>(collectionName);
            admin.Id = Guid.NewGuid().ToString();
            table.InsertOne(admin);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
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
        public ActionResult Edit(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.Id))
            {
                ViewBag.Mgs = "Please provide id";
                return View(admin);
            }
            var database = client.GetDatabase("universityDtabase");
            var table = database.GetCollection<Admin>("admin");
            table.ReplaceOne(c => c.Id == admin.Id, admin);
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
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
