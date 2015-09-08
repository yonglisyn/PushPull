using System.Collections.Generic;
using System.Threading.Tasks;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.DataAccessLayer.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskCard>> GetToDoTaskCardsAsync(int userId);
        Task<List<TaskCard>> GetCompletedTaskCardsAsync(int userId);
        Task<List<TaskCard>> GetFailedTaskCardsAsync(int userId);
        Task AddTaskCardAsync(TaskCard taskCard);
        Task RemoveTaskCardAsync(long taskCardId);
        Task<TaskCard> EditTaskCardAsync(TaskCard taskCard);
        Task<TaskCard> UpdateStatus(long taskCardId, CardStatus status);
    }
}