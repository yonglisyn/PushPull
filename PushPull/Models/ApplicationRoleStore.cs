using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PushPull.Models
{
    public class ApplicationRoleStore
        : RoleStore<ApplicationRole, int, ApplicationUserRole>
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}