using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class MainPageData : Base.PageData
    {
        [MaxLength(80)]
        public string Title { get; set; }

        public string ServerAddress { get; set; }

        [MaxLength(30)]
        public string YellowHint { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        #region Navigations
        public ICollection<Contact> Contacts { get; set; } = null!;
        #endregion
    }
}
