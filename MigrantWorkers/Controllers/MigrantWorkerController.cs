using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace MigrantWorkers.Controllers
{
    public class MigrantWorkerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public MigrantWorkerController(
           ApplicationDbContext db,
           IUserStore<IdentityUser> userStore,
           UserManager<IdentityUser> userManager,
           ILogger<RegisterModel> logger)
        {
            _db = db;
            _userStore = userStore;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var agencyusers = _db.AgencyUsers;
            return View(agencyusers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Migrant_Worker_Input obj)
        {
            if (ModelState.IsValid)
            {
                var iuser = new IdentityUser { UserName = obj.UserName };
                await _userStore.SetUserNameAsync(iuser, obj.UserName, CancellationToken.None);
                var result = await _userManager.CreateAsync(iuser, obj.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(iuser);

                    //await _signInManager.SignInAsync(iuser, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                var user = new MigrantWorkers.Models.User();
                var _userController = new UserController(_db);

                user.UserName = obj.UserName;
                user.UserType = obj.UserType;
                user.status = obj.status;
                var id = _userController.Create(user);

                var migrantWorker = new Migrant_Worker();
                migrantWorker.User = _db.Users.Find(id);
                migrantWorker.Fname = obj.Fname;
                migrantWorker.Lname = obj.Lname;
                migrantWorker.Fullname = obj.Fullname;
                migrantWorker.NameWithInit = obj.NameWithInit;
                migrantWorker.Email = obj.Email;
                migrantWorker.ContactNo = obj.ContactNo;
                migrantWorker.Country = obj.Country;
                migrantWorker.Workplace = obj.Workplace;
                migrantWorker.Workplaceaddress = obj.Workplaceaddress;
                migrantWorker.AddressInSriLanka = obj.AddressInSriLanka;
                migrantWorker.no_of_dependants = obj.no_of_dependants;
                migrantWorker.Dob = obj.Dob;
                migrantWorker.Age = obj.Age;
                migrantWorker.Visa_no = obj.Visa_no;
                migrantWorker.Passport_no = obj.Passport_no;
                migrantWorker.PassportExpDate = obj.PassportExpDate;
                migrantWorker.Agency = _db.Agencies.Find(obj.AgencyID);

                _db.Migrant_Workers.Add(migrantWorker);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var migrantWorker = _db.Migrant_Workers.Find(id);
            if (migrantWorker == null) return View("Error");
            return View(migrantWorker);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var migrantWorker = _db.Migrant_Workers.Find(id);
            if (migrantWorker == null) return View("Error");
            return View(migrantWorker);
        }

        [HttpPost]
        public IActionResult Edit(Migrant_Worker obj)
        {
            _db.Migrant_Workers.Update(obj);
            _db.SaveChanges();
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var migrantWorker = _db.Migrant_Workers.Find(id);
            _db.Migrant_Workers.Remove(migrantWorker);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
