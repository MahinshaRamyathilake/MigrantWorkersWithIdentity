using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace MigrantWorkers.Controllers
{
    public class AgencyUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public AgencyUserController(
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
        public async Task<IActionResult> Create(Agency_User_Input obj)
        {
            if(ModelState.IsValid)
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

                var agencyUser = new Agency_User();
                agencyUser.Id = id;
                agencyUser.AgencyID = obj.AgencyID;
                agencyUser.Fname = obj.Fname;
                agencyUser.Lname = obj.Lname;
                agencyUser.Address = obj.Address;
                agencyUser.Email = obj.Email;

                _db.AgencyUsers.Add(agencyUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var agencyuser = _db.AgencyUsers.Find(id);
            if (agencyuser == null) return View("Error");
            return View(agencyuser);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agencyuser = _db.AgencyUsers.Find(id);
            if (agencyuser == null) return View("Error");
            return View(agencyuser);
        }

        [HttpPost]
        public IActionResult Edit(Agency_User obj)
        {
            _db.AgencyUsers.Update(obj);
            _db.SaveChanges();
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var agencyUser = _db.AgencyUsers.Find(id);
            _db.AgencyUsers.Remove(agencyUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
