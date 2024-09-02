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
            return new MainPageViewModel(data);
        }

        public async Task SaveMainPage(MainPageViewModel viewModel)
        {
            MainPageData data = _db.MainPageData.OrderBy(m => m.Id).Last();
            data.GetValuesFromVM(viewModel);
            await _db.SaveChangesAsync();
        }
    }
}
