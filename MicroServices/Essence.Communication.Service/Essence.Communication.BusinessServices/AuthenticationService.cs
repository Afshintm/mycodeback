using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginRequest loginData, string token=null);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppSettingsConfigService _configuration;
        private readonly IHttpClientManagerNew _httpClient;
        public AuthenticationService(IHttpClientManagerNew httpClient,IAppSettingsConfigService configuration) 
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.SetBaseUrl(configuration.EssenceBaseUrl);
        }

        public async Task<LoginResponse> Login(LoginRequest loginData, string token = null)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Host", _configuration.HostName);

            _httpClient.ConfigurateHttpClient(headers);
            return await _httpClient.PostAsync<LoginResponse>("Login/Login", loginData);
        }

    }
}
