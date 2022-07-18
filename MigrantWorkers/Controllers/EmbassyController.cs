using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Controllers
{
    public class EmbassyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmbassyController(ApplicationDbContext db)
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
            var embassies = _db.Embassies;
            return View(embassies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Embassy obj)
        {
            if (ModelState.IsValid)
            {
                _db.Embassies.Add(obj);
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
            var embassy = _db.Embassies.Find(id);
            if (embassy == null) return View("Error");
            return View(embassy);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var embassy = _db.Embassies.Find(id);
            if (embassy == null) return View("Error");
            return View(embassy);
        }

        [HttpPost]
        public IActionResult Edit(Embassy obj)
        {
            if (ModelState.IsValid)
            {
                _db.Embassies.Update(obj);
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
            var embassy = _db.Embassies.Find(id);
            _db.Embassies.Remove(embassy);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
