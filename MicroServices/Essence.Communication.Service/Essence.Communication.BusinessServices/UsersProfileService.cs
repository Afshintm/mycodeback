using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IUserProfileService
    {
        Task<GetUsersResult> GetUsers(GetUsersRequest getUsersRequest);
    }

    public class UsersProfileService : BaseBusinessServices<GetUsersResult>, IUserProfileService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public UsersProfileService(IHttpClientManager httpClientManager, IConfiguration configuration, IAuthenticationService authenticationService) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public async Task<GetUsersResult> GetUsers(GetUsersRequest getUsersRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/GetUsers";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(getUsersRequest, loginResponse.token);
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
