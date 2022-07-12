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
        public int Create(User obj)
        {
            _db.Users.Add(obj);
            var _user = _db.SaveChanges();
            return _user;
        }
    }
}
