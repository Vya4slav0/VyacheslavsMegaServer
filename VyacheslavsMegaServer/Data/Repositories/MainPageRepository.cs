using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class MainPageRepository
    {
        private readonly AppDbContext _db;

        public MainPageRepository() 
        {
            _db = new AppDbContext();
        }

        public MainPageViewModel GetMainPageViewModel()
        {
            MainPageData data = _db.MainPageData.OrderBy(m => m.Id).Last();
            return new MainPageViewModel(data, new ContactsInfoRepository());
        }

        public async Task SaveMainPage(MainPageViewModel viewModel)
        {
            _db.MainPageData.OrderBy(m => m.Id).Last().GetValuesFromVM(viewModel);
            await _db.SaveChangesAsync();
        }
    }
}
