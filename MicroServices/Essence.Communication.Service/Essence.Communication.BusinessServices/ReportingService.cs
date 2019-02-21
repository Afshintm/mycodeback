using Essence.Communication.Models.Dtos;
using System.Threading.Tasks;
using Services.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Essence.Communication.Models.Config;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Essence.Communication.BusinessServices
{
    public interface IReportingService
    {
        Task<ActivityResult> GetResidentActivity(ActivityRequest activityRequest);
    }

    public class ReportingService : EssenceService, IReportingService
    {
        private readonly ILogger<ReportingService> _logger;
        public ReportingService(
            IHttpClientManager httpClientManager,
            IOptionsMonitor<ConfigOptions> monitor, 
            IAuthenticationService authenticationService, 
            ILogger<ReportingService> logger) 
        : base(httpClientManager, monitor, authenticationService, null, null)
        {
            _logger = logger;
        }

        public async Task<ActivityResult> GetResidentActivity(ActivityRequest activityRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            _logger.LogInformation("Getting Essence token ...");
            LoginResponse loginResponse = await GetEssenceToken();
            _logger.LogInformation("Calling ResidentActivity Api ...");
            var response = await SendRequestToEssence<ActivityResult>("report/GetResidentActivity", loginResponse.Token, activityRequest);
            return response;
        }
    }
}
