using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Areas.Admin.Models;
using VyacheslavsMegaServer.Data.Repositories;

namespace VyacheslavsMegaServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserReportsViewerController : Controller
    {
        UserReportsRepository _reportsReporitory;

        public UserReportsViewerController(UserReportsRepository reportsRepository) 
        { 
            _reportsReporitory = reportsRepository;
        }

        public async Task<IActionResult> Index()
        {
            UserReportsViewerViewModel model = new UserReportsViewerViewModel(await _reportsReporitory.GetAllReportsAsync());
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> RemoveSelected(UserReportsViewerViewModel model)
        {
            if (model.SelectedReportId.HasValue)
            {
                await _reportsReporitory.RemoveReportsByIdAsync(model.SelectedReportId.Value);
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
