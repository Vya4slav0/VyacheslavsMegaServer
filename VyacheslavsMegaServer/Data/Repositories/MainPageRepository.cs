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

            return new MainPageViewModel()
            {
                Title = data.Title.Replace("\n", "<br>"),
                ErrorMessage = data.ErrorMessage,
                ShowErrorMessage = data.ShowErrorMessage,
                YellowHint = data.YellowHint.Replace("\n", "<br>"),
                ServerAddress = data.ServerAddress,
                Description = data.Description.Replace("\n", "<br>"),
                Contacts = data.Contacts.ToList(),
                Creator = data.Contacts.First()
            };
        }
    }
}
