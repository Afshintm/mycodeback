using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IAccountService
    {
        Task<SuccessResponse> UserProfile(AddUserRequest addUserRequest);
        Task<SuccessResponse> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest);
        Task<SuccessResponse> AssociateUserToAccount(AssociateUserToAccountRequest associateUserToAccountRequest);
        Task<SuccessResponse> DeleteUser(DeleteUserRequest deleteUserRequest);
        Task<SuccessResponse> DeactivateUser(DeactivateUserRequest deactivateUserRequest);
        Task<SuccessResponse> DeleteAccount(DeleteAccountRequest deleteAccountRequest);
        Task<SuccessResponse> DisassociateUserFromAccount(DisassociateUserFromAccountRequest disassociateUserFromAccountRequest);
        Task<SuccessResponse> UpdateAccountInformation(UpdateAccountInformationRequest updateAccountInformationRequest);
        Task<SuccessResponse> UpdateUser(User updateUserRequest);
    }

    public class UserService : BaseBusinessServices<SuccessResponse>, IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IHttpClientManager httpClientManager, IConfiguration configuration, IAuthenticationService authenticationService) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public async Task<SuccessResponse> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/AddUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(addAndAssociateUserRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> AssociateUserToAccount(AssociateUserToAccountRequest associateUserToAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/AddUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(associateUserToAccountRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeactivateUser(DeactivateUserRequest deactivateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/DeactivateUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(deactivateUserRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeleteAccount(DeleteAccountRequest deleteAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/DeleteAccount";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(deleteAccountRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DeleteUser(DeleteUserRequest deleteUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/DeleteUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(deleteUserRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> DisassociateUserFromAccount(DisassociateUserFromAccountRequest disassociateUserFromAccountRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/DisassociateUserFromAccount";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(disassociateUserFromAccountRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public override void SetApiEndpointAddress()
        {
            //ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "report/GetResidentActivity";
        }

        public async Task<SuccessResponse> UpdateAccountInformation(UpdateAccountInformationRequest updateAccountInformationRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/UpdateAccountInformation";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(updateAccountInformationRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> UpdateUser(User updateUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/UpdateUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(updateUserRequest, loginResponse.Token);
                return result;
            });
            return response;
        }

        public async Task<SuccessResponse> UserProfile(AddUserRequest addUserRequest)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                userName = _configuration.GetSection("ApplicationSettings")["UserName"],
                password = _configuration.GetSection("ApplicationSettings")["Password"]
            };
            LoginResponse loginResponse = await _authenticationService.Login(loginRequest);
            ApiEndPoint = _configuration.GetSection("ApplicationSettings")["ApiEndPoint"] + "users/AddUser";
            var response = await Task.Run(async () =>
            {
                var result = await PostAsync(addUserRequest, loginResponse.Token);
                return result;
            });
            return response;
        }
    }
}
