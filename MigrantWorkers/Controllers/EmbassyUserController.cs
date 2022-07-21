using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Data;
using MigrantWorkers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace MigrantWorkers.Controllers
{
    public class EmbassyUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public EmbassyUserController(
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
            var embassyusers = _db.EmbassyUsers;
            return View(embassyusers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Embassy_User_Input obj)
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

                var embassyUser = new Embassy_User();
                embassyUser.Id = id;
                embassyUser.User = _db.Users.Find(id);
                embassyUser.EmbassyID = obj.EmbassyID;
                embassyUser.Fname = obj.Fname;
                embassyUser.Lname = obj.Lname;
                embassyUser.Address = obj.Address;
                embassyUser.Email = obj.Email;

                _db.EmbassyUsers.Add(embassyUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var embassyuser = _db.EmbassyUsers.Find(id);
            if (embassyuser == null) return View("Error");
            return View(embassyuser);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var embassyuser = _db.EmbassyUsers.Find(id);
            if (embassyuser == null) return View("Error");
            return View(embassyuser);
        }

        [HttpPost]
        public IActionResult Edit(Embassy_User obj)
        {
            _db.EmbassyUsers.Update(obj);
            _db.SaveChanges();
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var embassyuser = _db.EmbassyUsers.Find(id);
            _db.EmbassyUsers.Remove(embassyuser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
