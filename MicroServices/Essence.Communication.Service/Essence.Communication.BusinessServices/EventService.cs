using Essence.Communication.BusinessServices.ViewModel;
using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Dtos.Enums;
using Microsoft.Extensions.Configuration;
using Services.Utilities.DataAccess;
using Services.Utils;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using Essence.Communication.Models.Utility;

namespace Essence.Communication.BusinessServices
{
    public interface IEventService
    {
        Task<bool> ReceiveVendorEvent(EssenceEventObjectStructure eventObjectStructure);
        EventViewModel GetEvent(string id);
        Task<CloseEventsResponseViewModel> CloseEvent(CloseEventsRequestViewtModel closedEvent);
    }

    public class EventService : BaseBusinessServicesNew, IEventService
    {
        private readonly IAppSettingsConfigService _appSettingsConfigService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventCreator _eventCreater;
        private readonly IModelMapper _modelMapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IHttpClientManagerNew _httpClient;


        public EventService(
            IHttpClientManager httpClientManager,
            IAppSettingsConfigService appSettingsConfigService,
            IAuthenticationService authenticationService,
            IEventCreator eventCreater,
            IModelMapper mapper,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IHttpClientManagerNew httpClient
            ) : base()
        {
            _appSettingsConfigService = appSettingsConfigService;
            _authenticationService = authenticationService;
            _eventCreater = eventCreater; 
            _modelMapper = mapper;
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
        }

        public async Task<CloseEventsResponseViewModel> CloseEvent(CloseEventsRequestViewtModel closedEvent)
        {
            //TODO: get hsc event with filters from front end
            //TODO: implment repo to do complex operations based on filter
            
            //!!find by now is only for prototype
            var hscEvent = _unitOfWork.Repository<EventBase>().FindById(closedEvent.ids[0]);

            //get essence event with ID(s) to get accountId, in the prototype only 1 id is used
            var essenceId = hscEvent.VendorEventId;
            var essenceEvent = _unitOfWork.Repository<EssenceEventObjectStructure>().FindById(essenceId);
            if (essenceEvent == default(EssenceEventObjectStructure))
            {
                //log: no essenceEvent can be found
                return null;
            }

            //create payload
            var closeRequest = _modelMapper.MapToCloseEventRequetDTO(closedEvent);
            closeRequest.AccountNumber = essenceEvent.Account;

            //get token
            var login = new LoginRequest { password = _appSettingsConfigService.Password, userName = _appSettingsConfigService.UserName };
            var authResponse = await _authenticationService.Login(login);
            if(!authResponse.Value)
            {
                return new CloseEventsResponseViewModel { ResponseCode = ViewModels.ResponseCode.AuthenticationFailed };
            }

            //get close event response
            var header = new Dictionary<string, string>();
            header.Add("Authorization", authResponse.Token);
            header.Add("Host", _appSettingsConfigService.HostName);
            _httpClient.ConfigurateHttpClient(header);
            var result =  await _httpClient.PostAsync<CloseEventsResponse>("Alerts/CloseEvents", closeRequest);

            //map to viewmodel
            return _modelMapper.MapToCloseResponseDTO(result);
        }
        

        public EventViewModel GetEvent(string id)
        {
            //var result = _appData.GetEvent(id);
            var result = _unitOfWork.Repository<EventBase>().FindById(id);

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
            //_appData.AddVendorEvent(vendorEvent);
            _unitOfWork.Repository<EssenceEventObjectStructure>().Insert(vendorEvent);          

            //cast essenceEvent details into hcsEvent 
            var hscEvent = _eventCreater.Create(vendorEvent, new Account());
            //    _appData.AddNewEvent(hscEvent);
            _unitOfWork.Repository<EventBase>().Insert(hscEvent);

            _unitOfWork.Save();

            return await Task.Run(() => true);
        }

        private async Task<LoginResponse> GetEssenceToken()
        {
            var login = new LoginRequest { password = _appSettingsConfigService.Password, userName = _appSettingsConfigService.UserName };
            var authResponse = await _authenticationService.Login(login);

            return authResponse;
        }
    }
}
