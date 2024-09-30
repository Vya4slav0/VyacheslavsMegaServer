using Microsoft.EntityFrameworkCore;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Entities.Base;
using VyacheslavsMegaServer.Data.Repositories.Base;
using VyacheslavsMegaServer.Models;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class MainPageRepository : RepositoryBase
    {
        public async Task<MainPageData> GetMainPageData()
        {
            return await DB.MainPageData.OrderBy(m => m.Id).LastAsync();
        }

        public async Task SaveMainPage(MainPageData model)
        {
            DB.Update(model);
            await DB.SaveChangesAsync();
        }
    }
}
