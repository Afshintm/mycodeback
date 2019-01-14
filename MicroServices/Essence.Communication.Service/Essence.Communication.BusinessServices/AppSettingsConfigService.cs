using Microsoft.Extensions.Configuration;

namespace Essence.Communication.BusinessServices
{
    public interface IAppSettingsConfigService
    {
        string ServiceURL { get; }
        string UserName { get; }
        string Password { get; }
        string HostName { get; }
    }

    public class AppSettingsConfigService : IAppSettingsConfigService
    {
        private readonly IConfiguration _configuration;
        public AppSettingsConfigService (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ServiceURL { get => _configuration[SectionNames.App_ApiEndPoint]; }
        public string UserName { get => _configuration[SectionNames.App_UserName]; }
        public string Password { get => _configuration[SectionNames.App_Password]; }
        public string HostName { get => _configuration[SectionNames.App_HostName]; }
    }
}
