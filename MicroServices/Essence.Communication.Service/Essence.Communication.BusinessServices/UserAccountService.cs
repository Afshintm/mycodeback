using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IUserAccountService
    {
        Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest);
    }

    public class UserAccountService : BaseBusinessServices<UsersForAccountResult>, IUserAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public UserAccountService(IHttpClientManager httpClientManager, IConfiguration configuration, IAuthenticationService authenticationService) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public async Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/GetUsersForAccount";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(usersForAccountRequest, loginResponse.token);
                return result;
            });
            return response;
        }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }
    }
}
