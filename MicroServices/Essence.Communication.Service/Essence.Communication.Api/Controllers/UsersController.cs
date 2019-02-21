using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IAccountService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IUserAccountService _userAccountService;
        public UsersController(IAccountService userService, IUserProfileService userProfileService, IUserAccountService userAccountService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
            _userAccountService = userAccountService;
        }

        // GET: api/Users
        [Route("AddUser")]
        [HttpPost]
        public async Task<SuccessResponse> AddUser(AddUserRequest addUserRequest)
        {
            var result = await _userService.AddUser(addUserRequest);
            return result;
        }

        [Route("AddAndAssociateUser")]
        [HttpPost]
        public async Task<SuccessResponse> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest)
        {
            var result = await _userService.AddAndAssociateUser(addAndAssociateUserRequest);
            return result;
        }

        [Route("AssociateUserToAccount")]
        [HttpPost]
        public async Task<SuccessResponse> AssociateUserToAccount(AssociateUserToAccountRequest associateUserToAccountRequest)
        {
            var result = await _userService.AssociateUserToAccount(associateUserToAccountRequest);
            return result;
        }

        [Route("DeleteUser")]
        [HttpPost]
        public async Task<SuccessResponse> DeleteUser(DeleteUserRequest deleteUserRequest)
        {
            var result = await _userService.DeleteUser(deleteUserRequest);
            return result;
        }

        [Route("DeactivateUser")]
        [HttpPost]
        public async Task<SuccessResponse> DeactivateUser(DeactivateUserRequest deactivateUserRequest)
        {
            var result = await _userService.DeactivateUser(deactivateUserRequest);
            return result;
        }

        [Route("DeleteAccount")]
        [HttpPost]
        public async Task<SuccessResponse> DeleteAccount(DeleteAccountRequest deleteAccountRequest)
        {
            var result = await _userService.DeleteAccount(deleteAccountRequest);
            return result;
        }

        [Route("DisassociateUserFromAccount")]
        [HttpPost]
        public async Task<SuccessResponse> DisassociateUserFromAccount(DisassociateUserFromAccountRequest disassociateUserFromAccountRequest)
        {
            var result = await _userService.DisassociateUserFromAccount(disassociateUserFromAccountRequest);
            return result;
        }

        [Route("GetUsers")]
        [HttpPost]
        public async Task<GetUsersResult> GetUsers(GetUsersRequest getUsersRequest)
        {
            var result = await _userProfileService.GetUsers(getUsersRequest);
            return result;
        }

        [Route("GetUsersForAccount")]
        [HttpPost]
        public async Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest)
        {
            var result = await _userAccountService.GetUsersForAccount(usersForAccountRequest);
            return result;
        }

        [Route("UpdateAccountInformation")]
        [HttpPost]
        public async Task<SuccessResponse> UpdateAccountInformation(UpdateAccountInformationRequest updateAccountInformationRequest)
        {
            var result = await _userService.UpdateAccountInformation(updateAccountInformationRequest);
            return result;
        }
    }
}
