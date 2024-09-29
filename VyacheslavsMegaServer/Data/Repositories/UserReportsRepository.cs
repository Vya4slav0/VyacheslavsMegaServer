using Microsoft.EntityFrameworkCore;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories.Base;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class UserReportsRepository : RepositoryBase
    {
        public async Task SaveReportAsync(UserReport report)
        {
            DB.UserReports.Add(report);
            await DB.SaveChangesAsync();
        } 

        public async Task<List<UserReport>> GetAllReportsAsync()
        {
            return await DB.UserReports.ToListAsync();
        }

        public async Task<UserReport> GetReportByIdAsync(int id)
        {
            return await DB.UserReports.FirstAsync(r => r.Id == id);
        }

        public async Task RemoveReportsByIdAsync(int id)
        {
            UserReport reportToRemove = await DB.UserReports.FirstAsync(r => r.Id == id);
            DB.UserReports.Remove(reportToRemove);
            await DB.SaveChangesAsync();
        }
    }
}
