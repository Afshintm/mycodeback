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

        
        /// <summary>
        /// Receive event notification from Essence api
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <param name="eventObjectStructure">Essence event object structure</param>
        /// <returns>Ture if the essence event is valid</returns>
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


        /// <summary>
        /// Closing an essence event based on request from UI
        /// </summary>
        /// <param name="eventClosed">Event close request from UI</param>
        /// <returns>Response of closing event action</returns>
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
