using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Dtos; 
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IEventService
    {
        Task<bool> ReceiveEvent(EventObjectStructure eventObjectStructure);
    }

    public class EventService : BaseBusinessServices<SuccessResponse>, IEventService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventBus _eventBus;
        private readonly IEventDetailCreater _eventDetailCreater;

        public EventService(
            IHttpClientManager httpClientManager, 
            IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IEventBus eventBus,
            IEventDetailCreater eventDetailCreater
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
            _eventDetailCreater = eventDetailCreater;
        }

        public async Task<bool> ReceiveEvent(EventObjectStructure eventObjectStructure)
        {
            //TODO: return status ActionResult instead of boolean
            if (eventObjectStructure?.Event == null)
            {
                return false;
            } 
            
            var @event = eventObjectStructure.Event;
            @event.DetailsInstance = _eventDetailCreater.Create(@event);           
            

            var result = await _eventBus.PublishAsync(eventObjectStructure);
            var MessageId = result.MessageId;
            if (!string.IsNullOrEmpty(MessageId))
                return true;
            return false;
        }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }

    }
}
