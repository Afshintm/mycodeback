using Essence.Communication.DbContexts;
using Essence.Communication.Models.Dtos;
using Services.Utilities.DataAccess;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public class EssenceServiceBase
    {
        protected readonly IAppSettingsConfigService _appSettingsConfigService;
        protected readonly IAuthenticationService _authenticationService;
        protected readonly IModelMapper _modelMapper;
        protected readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        protected readonly IHttpClientManagerNew _httpClient;

        public EssenceServiceBase(IHttpClientManagerNew httpClientManager,
            IAppSettingsConfigService appSettingsConfigService,
            IAuthenticationService authenticationService,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IModelMapper modelMapper
            )
        {
            _appSettingsConfigService = appSettingsConfigService;
            _authenticationService = authenticationService;
            _httpClient = httpClientManager;
            _unitOfWork = unitOfWork;
            _modelMapper = modelMapper;

            //as a singleton intance, _httpClient's baseUrl canonly be set once
            _httpClient.SetBaseUrl(_appSettingsConfigService.EssenceBaseUrl);

        }

        protected virtual async Task<LoginResponse> GetEssenceToken(string passedInToken = null)
        {
            if (!string.IsNullOrEmpty(passedInToken))
            {
                return new LoginResponse(new SuccessResponse()) { Token = passedInToken };
            }
            var login = new LoginRequest { password = _appSettingsConfigService.Password, userName = _appSettingsConfigService.UserName };
            var authResponse = await _authenticationService.Login(login);

            return authResponse;
        }

        protected virtual async Task<T> SendRequestToEssence<T>(string path, Dictionary<string, string> headers, object payload) where T : class
        {
            _httpClient.ConfigurateHttpClient(headers);
            return await _httpClient.PostAsync<T>(path, payload);
        }
    }
}
