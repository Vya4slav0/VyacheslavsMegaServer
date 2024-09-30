using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Controllers
{
    public class UserReportsController : Controller
    {
        private readonly UserReportsRepository _reportsRepository;

        public UserReportsController(UserReportsRepository reportsRepository) 
        { 
            _reportsRepository = reportsRepository;
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(UserReport model)
        {
            if (ModelState.IsValid)
            {
                await _reportsRepository.SaveReportAsync(model);
                return Redirect(nameof(SuccessSending));
            }
            return View(model);
        }

        public IActionResult SuccessSending()
        {
            return View();
        }
    }
}
