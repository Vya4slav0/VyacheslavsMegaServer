using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class PartnersEditorViewModel
    {
        List<Partner> _partners;

        public PartnersEditorViewModel(List<Partner> partners)
        {
            _partners = partners;
        }

        public List<Partner> Partners => _partners;
    }
}
