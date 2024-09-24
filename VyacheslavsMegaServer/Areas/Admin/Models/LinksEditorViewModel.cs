using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class LinksEditorViewModel
    {
        List<ContactLink> _links;

        public LinksEditorViewModel(List<ContactLink> links)
        {
            _links = links;
        }

        public List<ContactLink> Links => _links;
    }
}
