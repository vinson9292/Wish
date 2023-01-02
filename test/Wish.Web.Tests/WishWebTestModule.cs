using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wish.EntityFrameworkCore;
using Wish.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Wish.Web.Tests
{
    [DependsOn(
        typeof(WishWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WishWebTestModule : AbpModule
    {
        public WishWebTestModule(WishEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WishWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WishWebMvcModule).Assembly);
        }
    }
}