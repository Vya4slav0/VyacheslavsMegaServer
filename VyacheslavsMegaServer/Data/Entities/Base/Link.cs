using System.ComponentModel.DataAnnotations;

namespace VyacheslavsMegaServer.Data.Entities.Base
{
    public abstract class Link : EntityBase
    {
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Текст ссылки")]
        public string Content { get; set; }

        [Display(Name = "Описание ссылки (префикс)")]
        public string? Description { get; set; }
    }
}
