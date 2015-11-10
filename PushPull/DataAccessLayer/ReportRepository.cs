using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class ReportRepository : IReportRepository
    {
        public async Task<List<WeeklyTaskReport>> GetWeeklyTaskReportAsync(int userId, int weekIndex)
        {
            using (var db = new ApplicationDbContext())
            {
                var reportList = db.WeeklyReports.Where(x => x.UserId == userId && x.WeekIndex == weekIndex);
                return await reportList.ToListAsync();
            }
        }

        public async Task<List<DailyTaskReport>> GetDailyTaskReportAsync(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var reportList = db.DailyReports.Where(x => x.UserId == userId);
                return await reportList.ToListAsync();
            }
        }
    }
}