namespace VyacheslavsMegaServer.Data.Repositories.Base
{
    public abstract class RepositoryBase
    {
        private readonly AppDbContext _db;

        public RepositoryBase()
        {
            _db = new AppDbContext();
        }   

        public AppDbContext DB => _db;
    }
}
