using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class LinksEditorViewModel<T> where T : Link
    {
        List<T> _links;

        public LinksEditorViewModel(List<T> links)
        {
            _links = links;
        }

        public List<T> Links => _links;
    }
}
