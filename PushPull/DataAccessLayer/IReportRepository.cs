using System.Collections.Generic;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public interface IReportRepository
    {
        Task<List<TaskReport>> GetOneWeekTaskReportAsync(int userId, int weekIndex);
    }
}