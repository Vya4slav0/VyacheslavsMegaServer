using Microsoft.EntityFrameworkCore;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class UserReportsRepository
    {
        private readonly AppDbContext _db;

        public UserReportsRepository() 
        {
            _db = new AppDbContext();
        }

        public async Task SaveReportAsync(UserReport report)
        {
            _db.UserReports.Add(report);
            await _db.SaveChangesAsync();
        } 

        public async Task<List<UserReport>> GetAllReports()
        {
            return await _db.UserReports.ToListAsync();
        }

        public async Task<UserReport> GetReportById(int id)
        {
            return await _db.UserReports.FirstAsync(r => r.Id == id);
        }
    }
}
