using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.Config;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Dtos.Enums;
using Essence.Communication.Models.Enums;
using Essence.Communication.Models.IdentityModels;
using Essence.Communication.Models.Utility;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.Utilities.DataAccess;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IUserAccountService
    {
        Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest, string token = null);
        Task<GetUsersResult> GetAllResidentUsers(string token = null);
        Task CreateAccountUserSnapShot();
    }

    public class UserAccountService : EssenceService, IUserAccountService
    {
        private IRepository<Account> _accountRepo;
        private IRepository<UserReference> _userRepo;
        private IRepository<Vendor> _vendorRepo;
        private IRepository<AccountUser> _accountUserRepo;
        private IRepository<AccountGroup> _accountGroupRepo;
        private readonly IIdentityUserProfileService _identifyService; 

        public UserAccountService(IHttpClientManager httpClientManager,
            IOptionsMonitor<ConfigOptions> optionsMonitor,
            IAuthenticationService authenticationService,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IModelMapper modelMapper,
            IIdentityUserProfileService identifyService
            ) : base(httpClientManager, optionsMonitor, authenticationService, unitOfWork, modelMapper)
        {
            _accountRepo = _unitOfWork.Repository<Account>();
            _userRepo = _unitOfWork.Repository<UserReference>();
            _vendorRepo = _unitOfWork.Repository<Vendor>();
            _accountUserRepo = _unitOfWork.Repository<AccountUser>();
            _accountGroupRepo = _unitOfWork.Repository<AccountGroup>();
            _identifyService = identifyService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId">Essence AccountId</param>
        /// <param name="token">Essence Authorization Token</param>
        /// <returns></returns>
        public async Task<UsersForAccountResult> GetUsersForAccount(string accountId, string token = null)
        {
            var accRequest = new UsersForAccountRequest { accountIdentifier = accountId };
            return await GetUsersForAccount(accRequest, token);
        }

        public async Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest, string token = null)
        {
            if (string.IsNullOrEmpty(token))
            {
                //get token
                var authToken = await GetEssenceToken();
                if (authToken.Response != (int)Models.Dtos.Enums.ResponseCode.Ok)
                {
                    //log getting token failing description
                    return new UsersForAccountResult(authToken);
                }
                token = authToken.Token;
            }

            //get all resident recores
            var header = new Dictionary<string, string>();
            header.Add("Authorization", token);
            header.Add("Host", _configOptions.ApplicationSettings.HostName);
            return await SendRequestToEssence<UsersForAccountResult>("users/GetUsersForAccount", header, usersForAccountRequest);
        }

        public async Task<GetUsersResult> GetAllResidentUsers(string token = null)
        {
            //get token
            var authToken = await GetEssenceToken(token);
            if (authToken.Response != (int)Models.Dtos.Enums.ResponseCode.Ok)
            {
                //log getting token failing description
                return new GetUsersResult(authToken);
            }

            //create request payload
            var getUserRequest = new GetUsersRequest();
            getUserRequest.userTypesFilter = new string[] { "Resident", "CareGiver" };

            //get all resident recores
            var header = new Dictionary<string, string>();
            header.Add("Authorization", authToken.Token);
            header.Add("Host", _configOptions.ApplicationSettings.HostName);
            //_httpClient.ConfigurateHttpClient(_appSettingsConfigService.EssenceBaseUrl, header);
            //return await _httpClient.PostAsync<GetUsersResult>("users/GetUsers", getUserRequest);

            //TODO refactor
            return await SendRequestToEssence<GetUsersResult>("users/GetUsers", header, getUserRequest);
        }

        public async Task CreateAccountUserSnapShot()
        {
            //get token
            var authToken = await GetEssenceToken(null);
            if (authToken.Response != (int)Models.Dtos.Enums.ResponseCode.Ok)
            {
                //log getting token failing description
                return;
            }

            //get all residents from Essence
            var accountsResult = await GetAllResidentUsers(authToken.Token);
            if (accountsResult.Response != (int)ResponseCode.Ok)
            {
                //log fail to get Residents
                return;
            }

            var newAccounts = new List<Account>();
            var newUsers = new List<UserReference>(); 
            var newAccountUserMapping = new List<AccountUser>();

            await HandleAccountUsers(accountsResult.users, 
                newAccounts, newUsers, newAccountUserMapping, 
                authToken.Token);

            
                //insert new accounts
             _accountRepo.InsertRange(newAccounts); 
            //create new users
            await _identifyService.AddBatchUsers(newUsers.Select(x => Map(x)).ToList()); 
            //create new mappings
            _accountUserRepo.InsertRange(newAccountUserMapping);
            _unitOfWork.Save();
            
            return ;
        }
        
        private IdentityUserProfile Map (UserReference userRef)
        {
            var user = new IdentityUserProfile();
            user.User = new ApplicationUser()
            {
                UserRef = userRef
            };

            user.Claims = new List<Claim>(); 
            AddClaim(JwtClaimTypes.FamilyName, userRef.LastName, user.Claims.ToList());
            AddClaim(JwtClaimTypes.GivenName, userRef.FirstName, user.Claims.ToList());
            AddClaim(JwtClaimTypes.PhoneNumber, userRef.CellPhoneNumber, user.Claims.ToList());
            AddClaim(JwtClaimTypes.Gender, userRef.Gender, user.Claims.ToList());
            AddClaim(JwtClaimTypes.Address, userRef.Address, user.Claims.ToList());
            

            user.Role = "CareGiver";
            return user;
        }    

        private bool AddClaim(string claimName, string value, List<Claim> ClaimList)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            ClaimList.Add (new Claim(claimName, value));
            return true;
        }
        private async Task<bool> HandleAccountUsers(UserResult[] residents, 
            List<Account> newAccounts, List<UserReference> newUsers, List<AccountUser> newAccountUsers,
            string token)
        {
            var currentUsers = _userRepo.GetAll();
            var currentAccounts = _accountRepo.GetAll();

            //get essence vendor 
            var vendor = _vendorRepo.Get(x => x.Name == EventVendors.ESSENCE).FirstOrDefault();
            if (vendor == default(Vendor))
            {
                //Add log
                return false;
            }

            //get account group
            //TODO: add the gropu for Testing
            var testGroup = _accountGroupRepo.Get(x => x.Name == "TestGroup").FirstOrDefault();

            //get all users linked to residents
            foreach (var resident in residents)
            {
                //check if the account has been added
                if (resident.accountDetails == null ||
                    (currentAccounts.Any(x => x.VendorAccountNo == resident.accountDetails?.account
                        && x.Vendor.Name.ToString().Equals(EventVendors.ESSENCE, StringComparison.CurrentCultureIgnoreCase))))
                {
                    //log account has been existed or can not find account details
                    continue;
                }
                   
                //handle accounts
                var account = new Account
                {
                    AccountNo = resident.accountDetails.serviceProviderAccountNumber,
                    VendorAccountNo = resident.accountDetails.account,
                    Vendor = vendor
                };

                if (testGroup != default(AccountGroup))
                {
                    account.Group = testGroup;
                }

                //add account into list
                newAccounts.Add(account);

                //get all users against the accout
                var userCollection = await GetUsersForAccount(resident.accountDetails.account, token);
                foreach (var user in userCollection.Users)
                {
                    if (user.UserDetails == null ||
                        newUsers.Any(x => x.VendorUserId == user.UserDetails?.UserId.ToString() && x.Vendor.Name == EventVendors.ESSENCE) ||
                        (currentUsers.Any(x => x.VendorUserId.Equals(user.UserDetails?.UserId.ToString(), StringComparison.CurrentCultureIgnoreCase) &&
                        x.Vendor.Name == EventVendors.ESSENCE)))
                    {
                        //log 
                        continue;
                    }

                    var userRef = new UserReference
                    {
                        Id = Guid.NewGuid().ToString(),
                        Vendor = vendor,
                        VendorUserId = user.UserDetails.UserId.ToString(),
                        UserType = user.UserDetails.UserType,
                        Email = user.UserDetails.Email,
                        UserName = user.UserDetails.UserName,
                        CellPhoneNumber = user.UserDetails.CellPhoneNumber,
                        Address = user.UserDetails.Address,
                        FirstName = user.UserDetails.FirstName,
                        LastName = user.UserDetails.LastName
                    };

                    newUsers.Add(userRef);

                    //check if user/account has been added
                    if (newAccountUsers.Any(x => x.UserId == userRef.Id && x.AccountId == account.Id))
                    {
                        continue;
                    }
                    var accUser = new AccountUser()
                    {
                        Account = account,
                        User = userRef,
                        CareGiverType = Map(user.UserDetails.CareGiverType)
                    };
                    newAccountUsers.Add(accUser);
                }
            }
            return true;

        }

        private CareGiverType Map(string userCareGiverType)
        {
            if (!Enum.TryParse<CareGiverType>(userCareGiverType, out CareGiverType result))
            {
                if (string.IsNullOrEmpty(userCareGiverType))
                {
                    return CareGiverType.NotCareGiver;
                }

                throw new NotSupportedException($"Cannot handle the user caregiver type: {userCareGiverType}");

            }
            return result;


        }


    }
}
