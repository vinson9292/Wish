using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Wish.Configuration.Dto;

namespace Wish.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WishAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
