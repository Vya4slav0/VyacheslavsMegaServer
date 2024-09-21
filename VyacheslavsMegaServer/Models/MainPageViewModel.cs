using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories;

namespace VyacheslavsMegaServer.Models
{
    public class MainPageViewModel : Base.PageViewModelBase
    {
        public MainPageViewModel() { }

        public MainPageViewModel(MainPageData mainPageData, ContactsInfoRepository contactsInfoRepository)
        {
            Title = mainPageData.Title.Replace("\n", "<br>");
            YellowHint = mainPageData.YellowHint.Replace("\n", "<br>");
            ShowDownloadButton = mainPageData.ShowDownloadButton;
            ErrorMessage = mainPageData.ErrorMessage;
            ShowErrorMessage = mainPageData.ShowErrorMessage;
            ServerAddress = mainPageData.ServerAddress;
            Description = mainPageData.Description;
            Creator = contactsInfoRepository.GetContactById(1).Result;

            PageTitle = mainPageData.PageTitle;
            MetatagDescription = mainPageData.MetatagDescription;
            MetatagKeywords = mainPageData.MetatagKeywords;
        }

        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Текст ошибки")]
        public string ErrorMessage { get; set; }

        [Display(Name = "Показать текст ошибки")]
        public bool ShowErrorMessage { get; set; }

        [Display(Name = "Показать кнопку скачивания")]
        public bool ShowDownloadButton { get; set; }

        [Required]
        [Display(Name = "Адрес сервера")]
        public string ServerAddress { get; set; }

        [Required]
        [Display(Name = "Жёлтая надпись")]
        public string YellowHint { get; set; }

        [Required]
        [Display(Name = "Описание проекта")]
        public string Description { get; set; }
        
        public Contact? Creator { get; set; }
    }
}
