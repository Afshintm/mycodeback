using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Essence.Communication.BusinessServices
{
    public interface IAppSettingsConfigService
    {
        string ServiceURL { get; }
        string UserName { get; }
        string Password { get; }
        string HostName { get; }
        string EssenceBaseUrl { get; }
        string[] SupportEssenceVersion { get; }
    }

    public class AppSettingsConfigService : IAppSettingsConfigService
    {
        private readonly IConfiguration _configuration;
        public AppSettingsConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ServiceURL { get => _configuration[SectionNames.App_ApiEndPoint]; }
        public string UserName { get => _configuration[SectionNames.App_UserName]; }
        public string Password { get => _configuration[SectionNames.App_Password]; }
        public string HostName { get => _configuration[SectionNames.App_HostName]; }
        public string EssenceBaseUrl { get => _configuration[SectionNames.App_EssenceBaseUrl]; }
        public string[] SupportEssenceVersion
        {
            get
            {
                return GetSupportedEssenceVersionList();
            }
        }

        private string[] GetSupportedEssenceVersionList()
        {
            var supportVersionSection = _configuration.GetSection(SectionNames.App_SupportedEssenceVersion);
            return supportVersionSection.AsEnumerable().Select(x => x.Value).ToArray();
        }
    }
}
