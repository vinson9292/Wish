using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Wish.Controllers
{
    public abstract class WishControllerBase: AbpController
    {
        protected WishControllerBase()
        {
            LocalizationSourceName = WishConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
