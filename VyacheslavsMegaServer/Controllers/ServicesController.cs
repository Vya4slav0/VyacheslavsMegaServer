using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VyacheslavsMegaServer.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult QR()
        {
            return File("~/img/siteQR.png", "image/png");
        }
    }
}
