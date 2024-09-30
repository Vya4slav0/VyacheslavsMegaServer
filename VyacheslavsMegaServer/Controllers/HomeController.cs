using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VyacheslavsMegaServer.Data.Repositories;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MainPageRepository _mainPageRepository;
        private readonly PartnersInfoRepository _partnersInfoRepository;
        private readonly ContactsInfoRepository _contactsInfoRepository;

        public HomeController(MainPageRepository mainPageRepository, PartnersInfoRepository partnersInfoRepository, ContactsInfoRepository contactsInfoRepository)
        {
            _mainPageRepository = mainPageRepository;
            _contactsInfoRepository = contactsInfoRepository;
            _partnersInfoRepository = partnersInfoRepository;
        }

        public async Task<IActionResult> Index()
        {
            MainPageViewModel model = new MainPageViewModel()
            {
                MainPageData = await _mainPageRepository.GetMainPageData(),
                Creator = await _contactsInfoRepository.GetContactById(1),
                PartnersData = await _partnersInfoRepository.GetAllPartners()
            };
            ViewBag.PageTitle = model.MainPageData.PageTitle;
            ViewBag.Keywords = model.MainPageData.MetatagKeywords;
            ViewBag.Description = model.MainPageData.MetatagDescription;
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
