using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IAuthenticationServiceNew
    {
        Task<LoginResponse> Login(LoginRequest loginData, string token = null);
    }
    public class AuthenticationServiceNew : IAuthenticationServiceNew
    {
        private readonly IAppSettingsConfigService _configuration;
        private readonly IHttpClientManagerNew httpClient;
        public AuthenticationServiceNew(IHttpClientManagerNew httpClientManager, IAppSettingsConfigService configuration)
        {
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest loginData, string token = null)
        {
            string baseUrl = $"{_configuration.EssenceBaseUrl}";
            var headers = new Dictionary<string, string>();
            headers.Add("Host", _configuration.HostName);

            httpClient.ConfigurateHttpClient(baseUrl, headers);

            return await httpClient.PostAsync<LoginResponse>("Login/Login", loginData);
        }

    }
}
