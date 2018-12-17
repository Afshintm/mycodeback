using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IReportingService _reportingService;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        public ValuesController(IReportingService reportingService, IUserService userService, IEventService eventService)
        {
            _reportingService = reportingService;
            _userService = userService;
            _eventService = eventService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("GetResidentActivity")]
        [HttpPost]
        public async Task<ActionResult<ActivityResult>> GetResidentActivity(ActivityRequest activityRequest)
        {
            var result = await _reportingService.GetResidentActivity(activityRequest);
            return result;
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> UserProfile(AddUserRequest addUserRequest)
        {
            var result = await _userService.UserProfile(addUserRequest);
            return result;
        }

        [Route("AddAndAssociateUser")]
        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddAndAssociateUser(AddAndAssociateUserRequest addAndAssociateUserRequest)
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

        //[Route("ReceiveEvent")]
        //[HttpPost]
        //public bool ReceiveEvent(EventObjectStructure eventObjectStructure)
        //{
        //    var result = async _eventService.ReceiveEvent(eventObjectStructure);
        //    return result;
        //}
    }
}
