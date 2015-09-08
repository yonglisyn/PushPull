using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Policy;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext()
            : base("TaskDbContext")
        {
        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<TaskCard> TaksCards{ get; set; }
        public DbSet<RecurredSchedule> RecurredSchedules { get; set; }
        public DbSet<ScheduleCard> ScheduleCards { get; set; } 
        public DbSet<AssetContainer> AssetContainers{ get; set; } 
        public DbSet<Punishment> Punishments{ get; set; } 
        public DbSet<Tag> Tags{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}