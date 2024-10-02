using Microsoft.EntityFrameworkCore;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories.Base;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class DonationCardsRepository : RepositoryBase
    {
        public async Task<List<DonationCard>> GetAllCards()
        {
            return await DB.DonationCards.ToListAsync();
        }

        public async Task<DonationCard> GetCardById(int cardId)
        {
            return await DB.DonationCards.FirstAsync(c => c.Id == cardId);
        }

        public async Task SaveCard(DonationCard donationCard)
        {
            if (donationCard.Id == 0)
                DB.Entry(donationCard).State = EntityState.Added;
            else
                DB.Entry(donationCard).State = EntityState.Modified;

            await DB.SaveChangesAsync();
        }

        public async Task RemoveCardById(int cardId)
        {
            DB.DonationCards.Remove(new DonationCard { Id = cardId });
            await DB.SaveChangesAsync();
        }
    }
}
