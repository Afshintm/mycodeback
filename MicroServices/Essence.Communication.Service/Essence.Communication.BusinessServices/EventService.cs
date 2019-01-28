using Essence.Communication.BusinessServices.ViewModel;
using Essence.Communication.DataAccessLayer;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos; 
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IEventService
    {
        Task<bool> ReceiveVendorEvent(EssenceEventObjectStructure eventObjectStructure);
        EventViewModel GetEvent(string id);
    }

    public class EventService : BaseBusinessServices<SuccessResponse>, IEventService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventCreater _eventCreater;
        private readonly IModelMapper _modelMapper;
        private readonly ApplicationData _appData;


        public EventService(
            IHttpClientManager httpClientManager,
            IConfiguration configuration,
            IAuthenticationService authenticationService,
            IEventCreater eventCreater,
            IModelMapper mapper,
            ApplicationData appData
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventCreater = eventCreater; 
            _modelMapper = mapper;

            _appData = appData;
        }

        public EventViewModel GetEvent(string id)
        {
            var result = _appData.GetEvent(id);

            return _modelMapper.MapToViewModel(result);
        }

        public async Task<bool> ReceiveVendorEvent(EssenceEventObjectStructure vendorEvent)
        {
            //TODO: exception 
            if (vendorEvent?.Event == null)
            {
                return await Task.Run(() => false); 
            }

                //save essenceEvent 
                _appData.AddVendorEvent(vendorEvent);

                //cast essenceEvent details into hcsEvent 
                var hscEvent = _eventCreater.Create(vendorEvent);
                _appData.AddNewEvent(hscEvent);

                return await Task.Run(() => true);
        }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }
    }
}
