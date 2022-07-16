using Microsoft.AspNetCore.Mvc;
using MigrantWorkers.Models;
using MigrantWorkers.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace MigrantWorkers.Controllers
{
    public class SLFBUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SLFBUserController(
            ApplicationDbContext db,
            IUserStore<IdentityUser> userStore,
            UserManager<IdentityUser> userManager,
            ILogger<RegisterModel> logger,
            SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userStore = userStore;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            var slfbUser = _db.SLFBUsers;
            return View(slfbUser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SLFB_User_Input obj)
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

                var slfbUser = new SLFB_User();
                slfbUser.UserID = id;
                slfbUser.Fname = obj.Fname;
                slfbUser.Lname = obj.Lname;
                slfbUser.Address = obj.Address;
                slfbUser.Email = obj.Email;

                _db.SLFBUsers.Add(slfbUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
