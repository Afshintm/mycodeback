using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.DataBaseServices;
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
        private readonly IEventDetailsCreater _eventDetailsCreater;
        private readonly IEventRepository _reposotory;

        public EventService(
            IHttpClientManager httpClientManager, 
            IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IEventBus eventBus,
            IEventDetailsCreater eventDetailsCreater,
            IEventRepository reposotory
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
            _eventDetailsCreater = eventDetailsCreater;
            _reposotory = reposotory;
        }

        public async Task<bool> ReceiveEvent(EventObjectStructure eventObjectStructure)
        {
            //TODO: return status ActionResult instead of boolean
            if (eventObjectStructure?.Event == null)
            {
                return false;
            } 
            
            var @event = eventObjectStructure.Event;
            @event.DetailsInstance = _eventDetailsCreater.Create(@event);           
            

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
