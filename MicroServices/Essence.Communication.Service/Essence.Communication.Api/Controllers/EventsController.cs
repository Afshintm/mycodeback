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
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/Events
        [Route("ReceiveEvent")]
        [HttpPost]
        public async Task<bool> ReceiveEvent(EventObjectStructure eventObjectStructure)
        {
            var result = await _eventService.ReceiveEvent(eventObjectStructure);
            return result;
        }
    }
}
