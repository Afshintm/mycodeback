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
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        
        [HttpGet]
        public async Task<bool> ReceiveMessage()
        {
            var result = await Task.Run(()=> true);
            return result;
        }


        // Post: api/Message
        [Route("PickMessage")]
        [HttpPost]
        public async Task<bool> PickMessage(EventObjectStructure eventObjectStructure)
        {
            var result = await _messageService.ReceiveMessage(eventObjectStructure);
            return result;
        }
    }
}
