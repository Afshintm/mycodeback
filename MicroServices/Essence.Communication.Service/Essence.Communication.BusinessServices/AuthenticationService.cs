using Essence.Communication.Models.Config;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly ConfigOptions _configuration;
        private readonly IHttpClientManager _httpClient;
        public AuthenticationService(IHttpClientManager httpClient, IOptionsMonitor<ConfigOptions> monitor) 
        {
            _configuration = monitor.CurrentValue;
            _httpClient = httpClient;
            _httpClient.SetBaseUrl(_configuration.ApplicationSettings.ApiEndPoint);
        }

        public async Task<LoginResponse> Login(LoginRequest loginData, string token = null)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Host", _configuration.ApplicationSettings.HostName);

            _httpClient.ConfigurateHttpClient(headers);
            return await _httpClient.PostAsync<LoginResponse>("Login/Login", loginData);
        }

    }
}
