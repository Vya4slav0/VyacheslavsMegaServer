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

        public async Task<List<UserReport>> GetAllReportsAsync()
        {
            return await _db.UserReports.ToListAsync();
        }

        public async Task<UserReport> GetReportByIdAsync(int id)
        {
            return await _db.UserReports.FirstAsync(r => r.Id == id);
        }

        public async Task RemoveReportsByIdAsync(int id)
        {
            UserReport reportToRemove = await _db.UserReports.FirstAsync(r => r.Id == id);
            _db.UserReports.Remove(reportToRemove);
            await _db.SaveChangesAsync();
        }
    }
}
