using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class DonationCardsEditorViewModel
    {
        List<DonationCard> _donationCards;

        public DonationCardsEditorViewModel(List<DonationCard> donationCards)
        {
            _donationCards = donationCards;
        }

        public List<DonationCard> DonationCards => _donationCards;
    }
}
