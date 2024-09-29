using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories.Base;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class MainPageRepository : RepositoryBase
    {
        public MainPageViewModel GetMainPageViewModel()
        {
            MainPageData data = DB.MainPageData.OrderBy(m => m.Id).Last();
            return new MainPageViewModel(data, new ContactsInfoRepository());
        }

        public async Task SaveMainPage(MainPageViewModel viewModel)
        {
            DB.MainPageData.OrderBy(m => m.Id).Last().GetValuesFromVM(viewModel);
            await DB.SaveChangesAsync();
        }
    }
}
