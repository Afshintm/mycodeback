﻿using System;
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
            private readonly IAccountService _userService;
            private readonly IEventService _eventService;
            public ValuesController(IReportingService reportingService, IAccountService userService, IEventService eventService)
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





        //[Route("ReceiveEvent")]
        //[HttpPost]
        //public bool ReceiveEvent(EventObjectStructure eventObjectStructure)
        //{
        //    var result = async _eventService.ReceiveEvent(eventObjectStructure);
        //    return result;
        //}
    }
}
