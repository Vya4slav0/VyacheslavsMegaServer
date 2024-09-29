using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class Partner : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Subtitle { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public bool ShowPartner { get; set; }

        public string LogoFileName { get; set; }

        [NotMapped]
        [ValidateNever]
        public string LogoAspPath => "~wwwroot/img/partners/" + LogoFileName;

        #region
        [ValidateNever]
        public virtual ICollection<PartnerLink> Links { get; set; }
        #endregion

    }
}
