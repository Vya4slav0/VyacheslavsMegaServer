using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VyacheslavsMegaServer.Data.Repositories;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MainPageViewModel model = new MainPageRepository().GetMainPageViewModel();
            ViewBag.PageTitle = model.PageTitle;
            ViewBag.Keywords = model.MetatagKeywords;
            ViewBag.Description = model.MetatagDescription;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(ErrorViewModel.PageType.Exception) 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult StatusCode(int code)
        {
            return View("Error", new ErrorViewModel(ErrorViewModel.PageType.StatusCode)
            {
                StatusCode = code,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
