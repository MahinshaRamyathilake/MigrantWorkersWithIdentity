using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Controllers
{
    public class AgencyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AgencyController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var agencies = _db.Agencies;
            return View(agencies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agency obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var agency = _db.Agencies.Find(id);
            if (agency == null) return View("Error");
            return View(agency);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agency = _db.Agencies.Find(id);
            if (agency == null) return View("Error");
            return View(agency);
        }

        [HttpPost]
        public IActionResult Edit(Agency obj)
        {
            if (ModelState.IsValid)
            {
                _db.Agencies.Update(obj);
                _db.SaveChanges();
                return View("Edit");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Delete(int id)
        {
            Agency agency = _db.Agencies.Find(id);
            _db.Agencies.Remove(agency);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
