using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Interfaces;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class UserReport : Base.EntityBase, FromVMConvertable<UserReportViewModel, UserReport>
    {
        public UserReport() 
        {
            TimestampCreated = DateTime.Now;
        }

        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(500)]
        public string ReportText { get; set; }

        public DateTime TimestampCreated { get; private set; }

        public UserReport GetValuesFromVM(UserReportViewModel viewModel)
        {
            Subject = viewModel.Subject;
            ReportText = viewModel.ReportText;
            return this;
        }
    }
}
