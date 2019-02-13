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
            ModelMapper modelMapper
            )
        {
            _appSettingsConfigService = appSettingsConfigService;
            _authenticationService = authenticationService;
            _httpClient = httpClientManager;
            _unitOfWork = unitOfWork;
            _modelMapper = modelMapper;

        }

        protected virtual async Task<LoginResponse> GetEssenceToken(string passedInToken = null)
        {
            if (string.IsNullOrEmpty(passedInToken))
            {
                return new LoginResponse(new SuccessResponse()) { token = passedInToken };
            }
            var login = new LoginRequest { password = _appSettingsConfigService.Password, userName = _appSettingsConfigService.UserName };
            var authResponse = await _authenticationService.Login(login);

            return authResponse;
        }
    }
}
