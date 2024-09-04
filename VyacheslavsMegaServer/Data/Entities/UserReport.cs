using System.ComponentModel.DataAnnotations;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class UserReport : Base.EntityBase
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Описание проблемы (максимум 500 символов)")]
        public string ReportText { get; set; }
    }
}
