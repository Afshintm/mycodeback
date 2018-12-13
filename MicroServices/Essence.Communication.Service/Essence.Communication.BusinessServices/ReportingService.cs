using System;
using System.Collections.Generic;
using System.Text;
using Essence.Communication.Models.Dtos;
using System.Threading.Tasks;
using Services.Utils;
using Microsoft.Extensions.Configuration;

namespace Essence.Communication.BusinessServices
{
    public interface IReportingService : IBaseBusinessService<ActivityResult>
    {
        Task<ActivityResult> GetResidentActivity(ActivityRequest activityRequest);
    }

    public class ReportingService : BaseBusinessServices<ActivityResult>, IReportingService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        public ReportingService(IHttpClientManager httpClientManager, IConfiguration configuration, IAuthenticationService authenticationService) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public async Task<ActivityResult> GetResidentActivity(ActivityRequest activityRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            //var result = await _apiManager.PostExternalAsync<ActivityResult>("report", "GetResidentActivity", activityRequest, loginResponse.token);
            var response = Task.Run(async () => {
                var result = await PostAsync(activityRequest, loginResponse.token);
                return result;
            });
            return response.Result;
        }

        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "report/GetResidentActivity";
        }
    }
}
