using Microsoft.AspNetCore.Mvc;

namespace MigrantWorkers.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
