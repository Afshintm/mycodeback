using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.BusinessServices.Model;
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
        Task<bool> ReceiveEssenceEvent(EssenceEventObjectStructure eventObjectStructure);
    }

    public class EventService : BaseBusinessServices<SuccessResponse>, IEventService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventBus _eventBus;
        private readonly IEventCreater _eventCreater;

        //todo: replace by unit of work
        private readonly IEssenceEventRepository _essenceReposotory;
        private readonly IHSCEventRepository _hscReposotory;

        public EventService(
            IHttpClientManager httpClientManager, 
            IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IEventBus eventBus,
            IEventCreater eventCreater,
            IEssenceEventRepository essenceReposotory,
            IHSCEventRepository hscReposotory
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
            _eventCreater = eventCreater;
            _essenceReposotory = essenceReposotory;
            _hscReposotory = hscReposotory;
        }

        public async Task<bool> ReceiveEssenceEvent(EssenceEventObjectStructure eventObjectStructure)
        {
            //TODO: return status ActionResult instead of boolean
            if (eventObjectStructure?.Event == null)
            {
                return false;
            }

            //save essenceEvent
            var ecsEventEntity = EssenceEventObjectStructure.CreateEntity(eventObjectStructure);
            _essenceReposotory.Add(ecsEventEntity);
            _essenceReposotory.Complete();
            //cast essenceEvent details into hcsEvent 
            var hscEvent = _eventCreater.Create(EssenceEventObjectStructure.CreateStructure(eventObjectStructure));

            //cast essent eventObjectstructure to hcs event in event creater with guid of eccense event
            var eventEntity = HSCEvent.MapToDAO(hscEvent);
            eventEntity.OriginalEventId = ecsEventEntity.EventId;
            //save hcsEvent into DB 
            _hscReposotory.Add(eventEntity);
            _hscReposotory.Complete();



            return true;
            //return false;
    }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }

    }
}
