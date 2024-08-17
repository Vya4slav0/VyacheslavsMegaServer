using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class Contact : EntityBase
    {
        [MaxLength(50)]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        #region Navigations
        public IdentityUser User { get; set; } = null!;

        public ICollection<Link> Links { get; set; } = null!;

        public MainPageData? MainPage { get; set; }
        #endregion
    }
}
