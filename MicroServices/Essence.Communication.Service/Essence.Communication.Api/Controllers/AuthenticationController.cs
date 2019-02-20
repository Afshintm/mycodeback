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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: api/Authentication
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _authenticationService.Login(loginRequest);
            return result;
        }

    }
}
