using System;
using System.Collections.Generic;
using Essence.Communication.BusinessServices;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAppSettingsConfigService _appSettingsConfig;
        public AccountsController(IAppSettingsConfigService appSettingsConfig)
        {
            _appSettingsConfig = appSettingsConfig;
        }

        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Accounts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
