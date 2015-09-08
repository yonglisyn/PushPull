using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class AccountDbContext:DbContext
    {
        public AccountDbContext():base("AccountDbContext")
        {
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}