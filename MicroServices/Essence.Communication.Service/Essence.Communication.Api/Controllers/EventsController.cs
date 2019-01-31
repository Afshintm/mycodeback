using System;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Utils;

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
        [Route("{id}")]
        public IActionResult GetById(string id)
        {
            //TODO: check author

            var result =  _eventService.GetEvent(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            
        }

        // Post: api/Message
        [Route("~/event")]
        [HttpPost]
        public async Task<IActionResult> PickEvent([FromBody]EssenceEventObjectStructure eventObjectStructure)
        {

            //validate essence headers
            var headers = Request.Headers;
            var result = await _eventService.ReceiveVendorEvent(eventObjectStructure);

            if (result)
                return Ok();
            return BadRequest();
        }

        // Post: api/Message
        [Route("$close")]
        [HttpPost]
        public async Task<ActionResult> CloseEvent([FromBody]CloseEventsRequestViewtModel eventClosed)
        {
            //TODO :validate headers 

            try
            {
                var result =  await _eventService.CloseEvent(eventClosed);
                return Ok(result);
            }
            catch (HttpClientManagerException ex)
            {
                return BadRequest(ex.ResponseConetent);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
