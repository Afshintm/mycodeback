using System.Collections.Generic;
using System.Linq;
using Essence.Communication.BusinessServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
            private readonly IReportingService _reportingService;
            private readonly IAccountService _userService;
            private readonly IMessageService _messageService;
        private readonly IAuthService _authService;

            public ValuesController(IReportingService reportingService, 
                IAccountService userService, 
                IMessageService messageService,
                IAuthService authService)
            {
                _reportingService = reportingService;
                _userService = userService;
                _messageService = messageService;
                _authService = authService;
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

        [Authorize]
        [HttpGet]
        [Route("~/Identity")]
        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        [Route("~/api/values/users")]
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            //var users = _authService.GetUsers();
            //if (users.Any())
            //    return Ok(users);
            return NotFound("No User found");
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
