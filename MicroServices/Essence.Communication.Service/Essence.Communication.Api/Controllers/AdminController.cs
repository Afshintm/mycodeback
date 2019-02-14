using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        /// <summary>
        /// Admin controller
        /// </summary>
        /// <param name="userAccountService"></param>
        public AdminController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [Route("Tsst")]
        [HttpGet]
        public async Task<ActionResult> InitializeAccountUsers2()
        {
            return Ok(new { a="aaa"});
        }


        [Route("IntializeAccountUsers")]
        [HttpPost]
        public async Task<ActionResult> InitializeAccountUsers()
        {
            try
            {
                if (await _userAccountService.InitializeAcountUsers())
                {
                    return Ok();
                }
                else
                    return new StatusCodeResult(500);
            }
            catch (Exception ex)
            {
                //log 
                throw ex;
            }
        }

    }
}