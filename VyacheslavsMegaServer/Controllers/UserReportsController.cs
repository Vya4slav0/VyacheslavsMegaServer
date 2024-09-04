using Microsoft.AspNetCore.Mvc;

namespace VyacheslavsMegaServer.Controllers
{
    public class UserReportsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
