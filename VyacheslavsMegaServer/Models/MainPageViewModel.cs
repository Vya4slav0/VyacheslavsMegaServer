using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Models
{
    public class MainPageViewModel : Base.PageViewModelBase
    {
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Текст ошибки")]
        public string ErrorMessage { get; set; }

        [Display(Name = "Показать текст ошибки")]
        public bool ShowErrorMessage { get; set; }

        [Display(Name = "Адрес сервера")]
        public string ServerAddress { get; set; }

        [Display(Name = "Жёлтая надпись")]
        public string YellowHint { get; set; }

        [Display(Name = "Описание проекта")]
        public string Description { get; set; }
        
        public Contact Creator { get; set; }
        
        public List<Contact> Contacts { get; set; }
    }
}
