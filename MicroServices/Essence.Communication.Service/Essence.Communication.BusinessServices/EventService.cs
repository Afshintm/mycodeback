using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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


        public EventService(
            IHttpClientManager httpClientManager, 
            IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IEventBus eventBus
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
        }

        public Task<bool> ReceiveEvent(EventObjectStructure eventObjectStructure)
        {
            var @event = eventObjectStructure;
            _eventBus.Publish(@event);
            return null;
        }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }
    }
}
