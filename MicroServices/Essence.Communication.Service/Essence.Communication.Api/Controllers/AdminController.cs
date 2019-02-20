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
        private readonly IIdentityUserProfileService _Iservice;
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccountService"></param>
        /// <param name="iservice"></param>
        public AdminController(IUserAccountService userAccountService, IIdentityUserProfileService iservice)
        {
            _userAccountService = userAccountService;
            _Iservice = iservice;

        }

        [Route("CreateAccountUserSnapShot")]
        [HttpPost]
        public async Task<ActionResult> CreateAccountUserSnapShot()
        {
            try
            {
                await _userAccountService.CreateAccountUserSnapShot();
                
                    return Ok(); 
            }
            catch (Exception ex)
            {
                //log 
                throw ex;
            }
        }

    }
}