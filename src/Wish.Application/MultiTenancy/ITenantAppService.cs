using Abp.Application.Services;
using Wish.MultiTenancy.Dto;

namespace Wish.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

