using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PushPull.Models;

namespace PushPull.Validators
{
    public class CustomUserValidator<TUser> : UserValidator<TUser, int>
        where TUser : ApplicationUser
    {
        public CustomUserValidator(UserManager<TUser, int> manager)
            : base(manager)
        {
            Manager = manager;
        }

        private UserManager<TUser, int> Manager { get; set; }

        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            var result = await base.ValidateAsync(item);
            if (!result.Succeeded)
            {
                return result;
            }
            var errors = new List<string>();
            await ValidateUserName(item, errors);
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }

        private async Task ValidateUserName(TUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add("User name is too short");
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                errors.Add("User name only allow letters, digits, . , _ and @");
            }
            else
            {
                var owner = await Manager.FindByNameAsync(user.UserName);
                if (owner != null)
                {
                    errors.Add("User name taken");
                }
            }
        }

    }
}

