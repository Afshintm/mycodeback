using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Dtos.Enums;
using Essence.Communication.Models.Utility;
using Microsoft.Extensions.Configuration;
using Services.Utilities.DataAccess;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IUserAccountService
    {
        Task<UsersForAccountResult> GetUsersForAccount(UsersForAccountRequest usersForAccountRequest, string token = null);
        Task<GetUsersResult> GetAllResidentUsers(string token = null);
        Task<bool> InitializeAcountUsers();
    }

    public class UserAccountService : EssenceServiceBase, IUserAccountService
    {
        public UserAccountService(IHttpClientManagerNew httpClientManager,
            IAppSettingsConfigService appSettingsConfigService,
            IAuthenticationService authenticationService,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            ModelMapper modelMapper
            ) : base(httpClientManager, appSettingsConfigService, authenticationService, unitOfWork, modelMapper)
        { }

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
                token = authToken.token;
            }

            //get all resident recores
            var header = new Dictionary<string, string>();
            header.Add("Authorization", token);
            header.Add("Host", _appSettingsConfigService.HostName);
            return await _httpClient.PostAsync<UsersForAccountResult>("users/GetUsersForAccount", usersForAccountRequest);
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
            header.Add("Authorization", authToken.token);
            header.Add("Host", _appSettingsConfigService.HostName);
            return await _httpClient.PostAsync<GetUsersResult>("users/GetUsers", getUserRequest);
        }

        public async Task<bool> InitializeAcountUsers()
        {
            //get token
            var authToken = await GetEssenceToken(null);
            if (authToken.Response != (int)Models.Dtos.Enums.ResponseCode.Ok)
            {
                //log getting token failing description
                return false;
            }

            //get all residents
            var accounts = await GetAllResidentUsers(authToken.token);

            //get all users linked to residents
            foreach (var resident in accounts.users)
            {
                if (resident.accountDetails == null)
                {
                    //log
                    continue;
                }
                //get users
                var userCollection = await GetUsersForAccount(resident.accountDetails.account, authToken.token);
                foreach (var user in userCollection.Users)
                {
                    //insert into db
                    await AddAccountUsers(user, resident.accountDetails, EventVendors.ESSENCE);
                }
            }
            return true;
        }

        //TODO: sync with identity
        private async Task<bool> AddAccountUsers(UserProfile user, Accountdetails account, string VendorName)
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
            //TODO:mapper dto to model
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

 
    }
}
