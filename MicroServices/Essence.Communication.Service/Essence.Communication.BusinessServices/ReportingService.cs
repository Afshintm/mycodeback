using Essence.Communication.Models.Dtos;
using System.Threading.Tasks;
using Services.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<ReportingService> _logger;
        public ReportingService(IHttpClientManager httpClientManager, IConfiguration configuration, IAuthenticationService authenticationService,ILogger<ReportingService> logger) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<ActivityResult> GetResidentActivity(ActivityRequest activityRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            _logger.LogInformation("Calling ResidentActivity Api ...");
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            //var result = await _apiManager.PostExternalAsync<ActivityResult>("report", "GetResidentActivity", activityRequest, loginResponse.token);
            var response = await Task.Run(async () => {
                var result = await PostAsync(activityRequest, loginResponse.token);
                return result;
            });
            return response;
        }

        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "report/GetResidentActivity";
        }
    }
}
