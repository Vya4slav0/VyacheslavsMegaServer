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
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Link> Links { get; set; } = null!;

        public int MainPageId { get; set; }
        public virtual MainPageData? MainPage { get; set; }
        #endregion
    }
}
