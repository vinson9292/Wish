using Abp.Authorization;
using Wish.Authorization.Roles;
using Wish.Authorization.Users;

namespace Wish.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
