using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainPageEditorController : Controller
    {
        private readonly MainPageRepository _mainPageRepository;

        public MainPageEditorController(MainPageRepository mainPageRepository) 
        { 
            _mainPageRepository = mainPageRepository;
        }

        public async Task<IActionResult> EditMainPage()
        {
            return View(await _mainPageRepository.GetMainPageData());
        }

        [HttpPost]
        public async Task<IActionResult> EditMainPage(MainPageData model) 
        {
            if (!ModelState.IsValid) return View(model);
            
            await _mainPageRepository.SaveMainPage(model);
            return Redirect("/admin");
        }
    }
}
