using Microsoft.AspNet.Identity;

namespace PushPull.Managers
{
    public class ApplicationUserManagerBase<TUser> : UserManager<TUser, int> where TUser : class, IUser<int>
    {
        public ApplicationUserManagerBase(IUserStore<TUser, int> store)
            : base(store)
        {
        }
    }
}