using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Controllers
{
    public class QueryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QueryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Query obj)
        {
            if (ModelState.IsValid)
            {
                _db.Queries.Add(obj);
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
            var query = _db.Queries.Find(id);
            if (query == null) return View("Error");
            return View(query);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var query = _db.Queries.Find(id);
            if (query == null) return View("Error");
            return View(query);
        }

        [HttpPost]
        public IActionResult Edit(Query obj)
        {
            if (ModelState.IsValid)
            {
                _db.Queries.Update(obj);
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
            var query = _db.Queries.Find(id);
            _db.Queries.Remove(query);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
