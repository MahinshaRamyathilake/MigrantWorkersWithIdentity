using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;

namespace MigrantWorkers.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Create(User obj)
        {
            if(ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "User Created Successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
    }
}
