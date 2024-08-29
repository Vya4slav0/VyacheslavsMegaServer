using System.ComponentModel.DataAnnotations;

namespace VyacheslavsMegaServer.Models.Base
{
    public abstract class PageViewModelBase
    {
        [Display(Name = "Заголовок страницы на вкладке браузера")]
        public string PageTitle { get; set; }

        [Display(Name = "Метатэг description")]
        public string MetatagDescription { get; set; }

        [Display(Name = "Метатэг keywords")]
        public string MetatagKeywords { get; set; }
    }
}
