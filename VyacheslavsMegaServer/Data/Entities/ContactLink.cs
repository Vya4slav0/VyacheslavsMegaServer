using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class ContactLink : Link
    {
        #region Navigations
        [Display(Name = "Принадлежит контакту:")]
        public int ContactId { get; set; }

        [ValidateNever]
        public virtual Contact? Contact { get; set; }
        #endregion
    }
}
