using System.Collections.Generic;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskCard>> GetAllTaskCardsAsync(int userId);
        Task<List<TaskCard>> GetCompletedTaskCardsAsync(int userId);
        Task<List<TaskCard>> GetGiveUpedTaskCardsAsync(int userId);
        Task AddTaskCardAsync(TaskCard taskCard);
        Task RemoveTaskCardAsync(long taskCardId);
        Task<TaskCard> EditTaskCardAsync(TaskCard taskCard);
    }
}