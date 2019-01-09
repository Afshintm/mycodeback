using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
   
        [HttpGet]
        public async Task<bool> ReceiveEvents()
        {
            var result = await Task.Run(()=> true);
            return result;
        }

        // Post: api/Message
        [Route("PickEvent")]
        [HttpPost]
        public async Task<bool> PickEvent([FromBody]EventObjectStructure eventObjectStructure)
        {
            var result = await _eventService.ReceiveEvent(eventObjectStructure);
            return result;
        }     
    }
}
