using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;
using Microsoft.AspNetCore.Identity;

namespace MigrantWorkers.Controllers
{
    public class FamilyDetailController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FamilyDetailController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var user = _db.Users.First(x => x.UserName == User.Identity.Name);
            var familydetails = _db.FamilyDetails.Where(x => x.UserID == user.Id);
            return View(familydetails);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FamilyDetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.FamilyDetails.Add(obj);
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
            var familydetails = _db.FamilyDetails.Find(id);
            if (familydetails == null) return View("Error");
            return View(familydetails);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var familydetails = _db.FamilyDetails.Find(id);
            if (familydetails == null) return View("Error");
            return View(familydetails);
        }

        [HttpPost]
        public IActionResult Edit(FamilyDetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.FamilyDetails.Update(obj);
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
            var familydetail = _db.FamilyDetails.Find(id);
            _db.FamilyDetails.Remove(familydetail);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
