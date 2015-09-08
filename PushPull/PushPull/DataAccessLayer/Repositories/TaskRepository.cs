using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using PushPull.DataAccessLayer.Repositories.Interfaces;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.DataAccessLayer.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        public async Task<List<TaskCard>> GetAllTaskCardsAsync(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Set<TaskCard>().ToListAsync();
            }
        }

        public async Task<List<TaskCard>> GetCompletedTaskCardsAsync(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Set<TaskCard>().Where(x=>x.Card.Status == CardStatus.Completed).ToListAsync();
            }
        }

        public async Task<List<TaskCard>> GetGiveUpedTaskCardsAsync(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Set<TaskCard>().Where(x => x.Card.Status == CardStatus.Failed).ToListAsync();
            }
        }

        public async Task AddTaskCardAsync(TaskCard taskCard)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Set<TaskCard>().Add(taskCard);
                await db.SaveChangesAsync();
            }
        }


        public async Task RemoveTaskCardAsync(long taskCardId)
        {
            using (var db = new ApplicationDbContext())
            {
                var taskCard = db.Set<TaskCard>().First(x => x.TaskId == taskCardId);
                db.Set<TaskCard>().Remove(taskCard);
                await db.SaveChangesAsync();
            }
        }

        public async Task<TaskCard> EditTaskCardAsync(TaskCard taskCard)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Set<TaskCard>().AddOrUpdate(taskCard);
                await db.SaveChangesAsync();
                return taskCard;
            }
        }
    }
}