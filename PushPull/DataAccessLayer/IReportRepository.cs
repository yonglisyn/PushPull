using System.Collections.Generic;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public interface IReportRepository
    {
        Task<List<WeeklyTaskReport>> GetWeeklyTaskReportAsync(int userId, int weekIndex);
        Task<List<DailyTaskReport>> GetDailyTaskReportAsync(int userId);
    }
}