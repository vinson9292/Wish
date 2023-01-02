using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wish.Authorization;

namespace Wish
{
    [DependsOn(
        typeof(WishCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WishApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WishAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WishApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
