using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Entities.Interfaces;

namespace VyacheslavsMegaServer.Models
{
    public class UserReportViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        [Display(Name = "Описание проблемы (максимум 500 символов)")]
        public string ReportText { get; set; }
    }
}
