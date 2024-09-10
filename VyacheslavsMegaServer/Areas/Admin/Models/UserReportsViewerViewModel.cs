using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    public class UserReportsViewerViewModel
    {
        private readonly List<UserReport> _userReports;

        public UserReportsViewerViewModel(List<UserReport> userReports) 
        {
            _userReports = userReports;
        }

        public UserReportsViewerViewModel() { }

        [Display(Name = "Список отчётов")]
        public List<SelectListItem>? ReportsId => _userReports?
            .OrderBy(r => r.TimestampCreated)
            .Select(r => new SelectListItem($"{r.TimestampCreated:dd.MM.yy}: {r.Subject}", r.Id.ToString())).ToList();

        public List<UserReport>? ReportsData => _userReports;

        public int? SelectedReportId { get; set; }
    }
}
