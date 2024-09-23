using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class Link : EntityBase
    {
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Текст ссылки")]
        public string Content { get; set; }

        [Display(Name = "Описание ссылки (префикс)")]
        public string? Description { get; set; }

        #region Navigations
        [Display(Name = "Принадлежит контакту:")]
        public int ContactId { get; set; }

        [ValidateNever]
        public virtual Contact? Contact { get; set; }
        #endregion
    }
}
