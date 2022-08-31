using Microsoft.AspNetCore.Mvc;

namespace MigrantWorkers.Controllers
{
    public class MigrantWorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
