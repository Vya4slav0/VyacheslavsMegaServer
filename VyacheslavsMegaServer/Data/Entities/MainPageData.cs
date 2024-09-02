using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class MainPageData : Base.PageData
    {
        [MaxLength(80)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string ErrorMessage { get; set; }

        public bool ShowErrorMessage { get; set; }

        public bool ShowDownloadButton { get; set; }

        public string ServerAddress { get; set; }

        [MaxLength(30)]
        public string YellowHint { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        #region Navigations
        public virtual ICollection<Contact> Contacts { get; set; } = null!;
        #endregion
    }
}
