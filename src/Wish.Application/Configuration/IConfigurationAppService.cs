using System.Threading.Tasks;
using Wish.Configuration.Dto;

namespace Wish.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
