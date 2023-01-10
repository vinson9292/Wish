using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Wish.Authorization;
using Wish.Todos;
using Wish.Todos.Dto;
using Wish.Todos.Dtos;

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
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateTodoInput, Todo>()
                      .ForMember(u => u.IsActive, options => options.MapFrom(input => (int)input.IsActive));
                config.CreateMap<UpdateTodoInput, Todo>()
                      .ForMember(u => u.IsActive, options => options.MapFrom(input => (int)input.IsActive));
                config.CreateMap<Todo, TodoDto>()
                      .ForMember(u => u.IsActive, options => options.MapFrom(input => (TaskState)input.IsActive));
            });
            Configuration.Settings.Providers.Add<MySettingProvider>();
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
