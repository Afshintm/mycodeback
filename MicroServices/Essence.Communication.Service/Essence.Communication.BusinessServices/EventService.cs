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
        private readonly IEventCreater _eventCreater;
        private readonly IModelMapper _modelMapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IHttpClientManagerNew _httpClient;


        public EventService(
            IHttpClientManager httpClientManager,
            IAppSettingsConfigService appSettingsConfigService,
            IAuthenticationService authenticationService,
            IEventCreater eventCreater,
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
            header.Add("Authorization", authResponse.token);
            header.Add("Host", _appSettingsConfigService.HostName);
            _httpClient.ConfigurateHttpClient(_appSettingsConfigService.EssenceBaseUrl, header);
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

        public async Task<UsersForAccountResult> GetUsersWithAccount(string accountId)
        {
            //get token
            var authToken = await GetEssenceToken();
            if (authToken.Response != (int)TokenResponse.Ok)
            {
                //log getting token failing description
                return null;
            }

            //create request payload
            var requestObj = new { accountIdentifier = accountId };

            //get all resident recores
            var header = new Dictionary<string, string>();
            header.Add("Authorization", authToken.token);
            header.Add("Host", _appSettingsConfigService.HostName);
            return await _httpClient.PostAsync<UsersForAccountResult>("users/GetUsersForAccount", requestObj);
        }

        public async Task<GetUsersResult> GetAllResidentUsers()
        {
            //get token
            var authToken = await GetEssenceToken();
            if (authToken.Response != (int)TokenResponse.Ok)
            {
                //log getting token failing description
                return null;
            }

            //create request payload
            var getUserRequest = new GetUsersRequest();
            getUserRequest.userTypesFilter = new string[] { "Resident", "CareGiver" };

            //get all resident recores
            var header = new Dictionary<string, string>();
            header.Add("Authorization", authToken.token);
            header.Add("Host", _appSettingsConfigService.HostName);
            return await _httpClient.PostAsync<GetUsersResult>("users/GetUsers", getUserRequest);
        }
        
        public async Task<bool> InitializeAcountUsers()
        {        
            //get all residents
            var accounts = await GetAllResidentUsers();

            //get all users linked to residents
            foreach (var acc in accounts.users)
            {
                if (acc.accountDetails == null)
                {
                    //log
                    continue;
                }
                //get users
                 var userCollection = await GetUsersWithAccount(acc.accountDetails.account);
                foreach (var user in userCollection.Users)
                {
                    //insert into db
                    await AddAccountUsers(user, acc.accountDetails, EventVendors.ESSENCE);
                }
            }
            return true;
        }

        //TODO: sync with identity
        private async Task<bool>AddAccountUsers(UserProfile user, Accountdetails account, string VendorName)
        {
            var accountRepo = _unitOfWork.Repository<Account>();
            var userRepo = _unitOfWork.Repository<UserReference>();
            var vendorRepo = _unitOfWork.Repository<Vendor>();
            var accountUserReo = _unitOfWork.Repository<AccountUser>();
            

            var vendor = vendorRepo.Get(x => x.Name == EventVendors.ESSENCE).FirstOrDefault();

            if (vendor == default(Vendor))
            {
                //Add log
                return false;
            }

            //check if current account exists
            //TODO:map dto to model
            Account acc = new Account { Id = account.serviceProviderAccountNumber, VendorAccountId = account.account, Vendor = vendor };
            if (accountRepo.FindById(account.serviceProviderAccountNumber) == default(Account))
            {
                //insert new account
                accountRepo.Add(acc);
            }
            else
            {
                //update

            }

            if (user.UserDetails == null)
            {
                //need to log
                _unitOfWork.Save();
            }

            //check if current user exists
            UserReference userRef = new UserReference
            {
                Id = Guid.NewGuid().ToString(),
                Vendor = vendor,
                VendorUserId = user.UserDetails.UserId.ToString(),
                UserType = user.UserDetails.UserType,
                Email = user.UserDetails.Email,
                Name = user.UserDetails.UserName
            };

            if (userRepo.Get(a => a.VendorUserId == user.UserDetails.UserId.ToString()).FirstOrDefault() == default(UserReference))
            {
                //insert new account
                userRepo.Add(userRef);
            }
            else
            {
                //update

            }
            //insert new user
            
            if (accountUserReo.Get(x => x.AccountId == acc.Id && x.UserId == userRef.Id).FirstOrDefault() == default(AccountUser))
            {
                var accUser = new AccountUser { Account = acc, User = userRef };
            }

            _unitOfWork.Save();
            return true;
        }

        private async Task<LoginResponse> GetEssenceToken()
        {
            var login = new LoginRequest { password = _appSettingsConfigService.Password, userName = _appSettingsConfigService.UserName };
            var authResponse = await _authenticationService.Login(login);

            return authResponse;
        }

 
    }
}
