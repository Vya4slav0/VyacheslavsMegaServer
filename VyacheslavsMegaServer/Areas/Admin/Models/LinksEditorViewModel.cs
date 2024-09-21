using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class LinksEditorViewModel
    {
        List<Link> _links;

        public LinksEditorViewModel(List<Link> links)
        {
            _links = links;
        }

        public List<Link> Links => _links;
    }
}
