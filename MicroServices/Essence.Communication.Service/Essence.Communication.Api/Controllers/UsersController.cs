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

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [Route("AddUser")]
        [HttpPost]
        public async Task<SuccessResponse> UserProfile(AddUserRequest addUserRequest)
        {
            var result = await _userService.UserProfile(addUserRequest);
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
            var result = await _userService.GetUsers(getUsersRequest);
            return result;
        }

        [Route("GetUsersForAccount")]
        [HttpPost]
        public async Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest)
        {
            var result = await _userService.GetUsersForAccount(usersForAccountRequest);
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
