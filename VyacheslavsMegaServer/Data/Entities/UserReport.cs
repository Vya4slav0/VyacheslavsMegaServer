using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Interfaces;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class UserReport : Base.EntityBase, FromVMConvertable<UserReportViewModel, UserReport>
    {
        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(500)]
        public string ReportText { get; set; }

        public UserReport GetValuesFromVM(UserReportViewModel viewModel)
        {
            Subject = viewModel.Subject;
            ReportText = viewModel.ReportText;
            return this;
        }
    }
}
