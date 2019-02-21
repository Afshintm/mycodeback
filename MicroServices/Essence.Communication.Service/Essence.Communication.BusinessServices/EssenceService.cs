using Essence.Communication.DbContexts;
using Essence.Communication.Models.Config;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Options;
using Services.Utilities.DataAccess;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public abstract class EssenceService
    {
        protected readonly ConfigOptions _configOptions;
        protected readonly IAuthenticationService _authenticationService;
        protected readonly IModelMapper _modelMapper;
        protected readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        protected readonly IHttpClientManager _httpClient;

        public EssenceService(IHttpClientManager httpClientManager,
            IOptionsMonitor<ConfigOptions> optionsMonitor,
            IAuthenticationService authenticationService,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IModelMapper modelMapper
            )
        {
            _configOptions = optionsMonitor.CurrentValue;
            _authenticationService = authenticationService;
            _httpClient = httpClientManager;
            _unitOfWork = unitOfWork;
            _modelMapper = modelMapper;

            //as a singleton intance, _httpClient's baseUrl canonly be set once
            _httpClient.SetBaseUrl(_configOptions.ApplicationSettings.ApiEndPoint);

        }

        protected async Task<LoginResponse> GetEssenceToken(string passedInToken = null)
        {
            if (!string.IsNullOrEmpty(passedInToken))
            {
                return new LoginResponse(new SuccessResponse()) { Token = passedInToken };
            }
            var login = new LoginRequest { password = _configOptions.ApplicationSettings.Password, userName = _configOptions.ApplicationSettings.UserName };
            var authResponse = await _authenticationService.Login(login);

            return authResponse;
        }

        protected async Task<T> SendRequestToEssence<T>(string path, string token, object payload) where T : class
        {
            return await SendRequestToEssence<T>(path, new Dictionary<string, string> { { "Authorization", token } }, payload);
        }

        protected async Task<T> SendRequestToEssence<T>(string path, Dictionary<string, string> headers, object payload) where T : class
        {
            _httpClient.ConfigurateHttpClient(headers);
            return await _httpClient.PostAsync<T>(path, payload);
        }
    }
}
