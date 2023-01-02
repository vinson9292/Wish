using System.Threading.Tasks;
using Abp.Application.Services;
using Wish.Sessions.Dto;

namespace Wish.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
