using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Models
{
    public class DonationPageViewModel
    {
        public List<DonationCard> DonationCards { get; set; }

        public bool HasCards => DonationCards != null && DonationCards.Any();
    }
}
