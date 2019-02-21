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
    public interface IAccountService
    {
        Task<SuccessResponse> AddUser(AddUserRequest addUserRequest);
        Task<SuccessResponse> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest);
        Task<SuccessResponse> AssociateUserToAccount(AssociateUserToAccountRequest associateUserToAccountRequest);
        Task<SuccessResponse> DeleteUser(DeleteUserRequest deleteUserRequest);
        Task<SuccessResponse> DeactivateUser(DeactivateUserRequest deactivateUserRequest);
        Task<SuccessResponse> DeleteAccount(DeleteAccountRequest deleteAccountRequest);
        Task<SuccessResponse> DisassociateUserFromAccount(DisassociateUserFromAccountRequest disassociateUserFromAccountRequest);
        Task<SuccessResponse> UpdateAccountInformation(UpdateAccountInformationRequest updateAccountInformationRequest);
        Task<SuccessResponse> UpdateUser(User updateUserRequest);
    }

    public class UserService : EssenceService, IAccountService
    {
        public UserService(IHttpClientManager httpClientManager, IOptionsMonitor<ConfigOptions> monitor, IAuthenticationService authenticationService) : base(httpClientManager, monitor, authenticationService, null, null)
        {
        }

        public async Task<SuccessResponse> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            //ApiEndPoint = new Uri(new Uri(_configOptions.ApplicationSettings.ApiEndPoint), "users/AddUser").AbsoluteUri;
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/AddAndAssociateUser", loginResponse.Token, addAndAssociateUserRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> AssociateUserToAccount(AssociateUserToAccountRequest associateUserToAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            //ApiEndPoint = new Uri(new Uri(_configOptions.ApplicationSettings.ApiEndPoint), "users/AddUser").AbsoluteUri;
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/AssociateUserToAccount", loginResponse.Token, associateUserToAccountRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeactivateUser(DeactivateUserRequest deactivateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/DeactivateUser", loginResponse.Token, deactivateUserRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeleteAccount(DeleteAccountRequest deleteAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/DeleteAccount", loginResponse.Token, deleteAccountRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeleteUser(DeleteUserRequest deleteUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            //ApiEndPoint = new Uri(new Uri(_configOptions.ApplicationSettings.ApiEndPoint), "users/DeleteUser").AbsoluteUri;
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/DeleteUser", loginResponse.Token, deleteUserRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DisassociateUserFromAccount(DisassociateUserFromAccountRequest disassociateUserFromAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            //ApiEndPoint = new Uri(new Uri(_configOptions.ApplicationSettings.ApiEndPoint), "users/DisassociateUserFromAccount").AbsoluteUri;
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/DisassociateUserFromAccount", loginResponse.Token, disassociateUserFromAccountRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> UpdateAccountInformation(UpdateAccountInformationRequest updateAccountInformationRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/UpdateAccountInformation", loginResponse.Token, updateAccountInformationRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> UpdateUser(User updateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/UpdateUser", loginResponse.Token, updateUserRequest);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> AddUser(AddUserRequest addUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configOptions.ApplicationSettings.UserName,
                password = _configOptions.ApplicationSettings.Password
            };
            LoginResponse loginResponse = await GetEssenceToken();
            var response = await Task.Run(async () =>
            {
                var result = await SendRequestToEssence<SuccessResponse>("users/AddUser", loginResponse.Token, addUserRequest);
                return result;
            });
            return response;
        }
    }
}
