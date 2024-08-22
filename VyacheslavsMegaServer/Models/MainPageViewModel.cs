using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Models
{
    public class MainPageViewModel
    {
        public string Title { get; set; }

        public string ServerAddress { get; set; }
        
        public string YellowHint { get; set; }
        
        public string Description { get; set; }
        
        public Contact Creator { get; set; }
        
        public List<Contact> Contacts { get; set; }
    }
}
