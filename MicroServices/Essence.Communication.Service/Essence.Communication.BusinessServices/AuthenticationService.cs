using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IAuthenticationService : IBaseBusinessService<LoginResponse>
    {
        Task<LoginResponse> Login(LoginRequest loginData, string token=null);
    }
    public class AuthenticationService : BaseBusinessServices<LoginResponse>, IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationService(IHttpClientManager httpClientManager, IConfiguration configuration) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
        }
        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApiEndPoint")["login"];
        }

        public async Task<LoginResponse> Login(LoginRequest loginData, string token = null) {

            var response = Task.Run(async() => {
                var result =  await PostAsync(loginData,token);
                return result;
            });
            return response.Result;
        }

    }
}
