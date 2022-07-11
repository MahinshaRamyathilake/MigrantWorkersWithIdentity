using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Models;
using MigrantWorkers.Data;

namespace MigrantWorkers.Controllers
{
    public class SLFBUserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SLFBUserController(ApplicationDbContext db)
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
        public IActionResult Create(SLFB_User obj)
        {
            if (ModelState.IsValid)
            {
                _db.SFBUsers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
