using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class ReportRepository : IReportRepository
    {
        public async Task<List<TaskReport>> GetOneWeekTaskReportAsync(int userId, int weekIndex)
        {
            using (var db = new ApplicationDbContext())
            {
                var reportList = db.Reports.Where(x => x.UserId == userId && x.WeekIndex == weekIndex);
                return await reportList.ToListAsync();
            }
        }
    }
}