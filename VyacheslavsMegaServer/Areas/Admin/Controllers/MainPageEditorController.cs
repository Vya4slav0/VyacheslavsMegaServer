using Microsoft.AspNetCore.Mvc;

namespace VyacheslavsMegaServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainPageEditorController : Controller
    {
        public IActionResult EditMainPage()
        {
            return View();
        }
    }
}
