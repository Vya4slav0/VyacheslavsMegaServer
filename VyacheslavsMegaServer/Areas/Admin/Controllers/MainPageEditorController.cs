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

        public IActionResult EditMainPage()
        {
            return View(_mainPageRepository.GetMainPageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditMainPage(MainPageViewModel model) 
        {
            if (ModelState.IsValid)
            {
                await _mainPageRepository.SaveMainPage(model);
            }
            return Redirect("/admin");
        }
    }
}
