using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using PushPull.Managers;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEf(ApplicationDbContext db) {
            db.Configuration.LazyLoadingEnabled = true;
            var userManager = new ApplicationUserManager(new ApplicationUserStore(db));
            var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(db));
            const string password = "Pu$hPull@123456";
            const string roleName = "Admin";

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                roleManager.Create(role);
            }
            var hashedPw = new PasswordHasher().HashPassword(password);
            var admins = new List<ApplicationUser>
            {
                new ApplicationUser {Id=1,UserName = "Yongli", Email = "sylyongli@gmail.com", EmailConfirmed = true,LockoutEnabled = true,PasswordHash = hashedPw},
                new ApplicationUser {Id=2,UserName = "Test", Email = "test@hotmail.com", EmailConfirmed = true,LockoutEnabled = true,PasswordHash = hashedPw}
            };
           
            admins.ForEach(x =>
            {
                var user = userManager.FindByName(x.UserName);
                if (user == null)
                {
                    userManager.Create(x);
                }
                var rolesForUser = userManager.GetRoles(x.Id);
                if (!rolesForUser.Contains(role.Name))
                {
                    userManager.AddToRole(x.Id, role.Name);
                }
            });
            
        }
    }
}