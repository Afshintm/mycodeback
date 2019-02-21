using Essence.Communication.Models.Config;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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

    public class UsersProfileService : EssenceService, IUserProfileService
    {

        public UsersProfileService(IHttpClientManager httpClientManager, IOptionsMonitor<ConfigOptions> monitor, IAuthenticationService authenticationService) : base(httpClientManager, monitor, authenticationService, null, null)
        {
        }

        public async Task<GetUsersResult> GetUsers(GetUsersRequest getUsersRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<GetUsersResult>("users/GetUsers", loginResponse.Token, getUsersRequest);
                return result;
            });
            return response;

        }
    }
}
