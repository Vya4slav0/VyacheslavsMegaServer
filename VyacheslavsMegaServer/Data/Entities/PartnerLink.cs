using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class PartnerLink : Link
    {
        #region Navigations
        [Display(Name = "Принадлежит партнёру:")]
        public int PartnerId { get; set; }

        [ValidateNever]
        public virtual Partner? Partner { get; set; }
        #endregion
    }
}
