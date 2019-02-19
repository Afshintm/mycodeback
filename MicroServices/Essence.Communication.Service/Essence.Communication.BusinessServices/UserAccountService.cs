﻿using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Dtos.Enums;
using Essence.Communication.Models.IdentityModels;
using Essence.Communication.Models.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        Task<bool> PullAccountUsers();
    }

    public class UserAccountService : EssenceServiceBase, IUserAccountService
    {
        private IRepository<Account> _accountRepo;
        private IRepository<UserReference> _userRepo;
        private IRepository<Vendor> _vendorRepo;
        private IRepository<AccountUser> _accountUserRepo;
        private IRepository<AccountGroup> _accountGroupRepo;

        private readonly IIdentityUserProfileService _identifyService; 

        public UserAccountService(IHttpClientManagerNew httpClientManager,
            IAppSettingsConfigService appSettingsConfigService,
            IAuthenticationService authenticationService,
            IUnitOfWork<ApplicationDbContext> unitOfWork,
            IModelMapper modelMapper,
            IIdentityUserProfileService identifyService
            ) : base(httpClientManager, appSettingsConfigService, authenticationService, unitOfWork, modelMapper)
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
            header.Add("Host", _appSettingsConfigService.HostName);
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
            header.Add("Host", _appSettingsConfigService.HostName);
            //_httpClient.ConfigurateHttpClient(_appSettingsConfigService.EssenceBaseUrl, header);
            //return await _httpClient.PostAsync<GetUsersResult>("users/GetUsers", getUserRequest);

            //TODO refactor
            return await SendRequestToEssence<GetUsersResult>("users/GetUsers", header, getUserRequest);
        }

        public async Task PullAccountUsers()
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

            var existingAccounts = new List<Account>();
            var existingUsers = new List<UserReference>();
            var existingAccountUserMapping = new List<AccountUser>();

            var allExistingAccounts = _accountRepo.GetAll();
            var allExistingUsers = _userRepo.GetAll();
            var allExistingAccountUserMapping = _accountUserRepo.GetAll();

            await AddAccountUsers(accountsResult.users, newAccounts, newUsers, newAccountUserMapping, existingAccounts, existingUsers, existingAccountUserMapping, allExistingAccounts, allExistingUsers, allExistingAccountUserMapping, authToken.Token);

            //insert new accounts
            _accountRepo.InsertRange(newAccounts);

            //create new users
            await _identifyService.AddBatchUsers(GetUserProfiles(newUsers)); 

            //create new mappings
            _accountUserRepo.InsertRange(newAccountUserMapping);
            _unitOfWork.Save();
            
            return ;
        }
        

        public async Task<bool> SetIdentityUsers(IEnumerable <UserReference> users)
        {
            foreach(var user in users)
            {
                var identityUser = new ApplicationUser
                {
                    Id = user.Id,
                    //UserName = user.UserName,
                    //Email = user.Email,
                    PhoneNumber = user.CellPhoneNumber
                };

                //add user
                var result = await _userManager.CreateAsync(identityUser, GeneralPassword);
                if (!result.Succeeded)
                {
                    //log it
                    continue;
                }

                //add user claims
                result = await _userManager.AddClaimsAsync(identityUser, new Claim[] {
                     new Claim("given_name", user.FirstName),
                     new Claim("family_name", user.LastName),
                     new Claim("UserType", user.UserType)
                });
                if (!result.Succeeded)
                {
                    //log it
                    continue;
                }

                //TODO: user should have multiple roles
                //add user roles
                result = await _userManager.AddToRoleAsync(identityUser, MapRoles(user.UserType));
                if (!result.Succeeded)
                {
                    //log it
                    continue;
                }

            }

            return true;
        }     

        private List<IdentityUserProfile> GetUserProfiles(List<UserReference> users)
        {
            var result = new List<IdentityUserProfile>();
            return result;
        }


        private async Task<bool> AddAccountUsers(UserResult[] users, List<Account> accountList, List<UserReference> userList, List<AccountUser> accountUserList, string token)
        {
            var existedAccount = _accountRepo.GetAll();
            var existedUsers = _userRepo.GetAll();
            var existedAccountUsers = _accountUserRepo.GetAll();

            var vendor = _vendorRepo.Get(x => x.Name == EventVendors.ESSENCE).FirstOrDefault();
            if (vendor == default(Vendor))
            {
                //Add log
                return false;
            }

            //TODO: for Testing
            var testGroup = _accountGroupRepo.Get(x => x.Name == "TestGroup").FirstOrDefault();

            //get all users linked to residents
            foreach (var resident in users)
            {
                if (resident.accountDetails == null)
                {
                    //log
                    continue;
                }

                //handle accounts
                var account = new Account
                {
                    AccountNo = resident.accountDetails.serviceProviderAccountNumber,
                    VendorAccountNo = resident.accountDetails.account,
                    Vendor = vendor,
                    Group = testGroup
                };

                //check if account has been existed
                var accFound = existedAccount.Where(x => x.VendorAccountNo == account.VendorAccountNo && x.Vendor.Name == EventVendors.ESSENCE).FirstOrDefault();
                if (accFound == default(Account))
                {
                    //check if account has been added in the list
                    if (!accountList.Any(x => x.VendorAccountNo == account.VendorAccountNo && x.Vendor.Name == EventVendors.ESSENCE))
                    {
                        accountList.Add(account);
                    }
                }
                else
                {
                    //account.Id = accFound.Id;

                    //TODO: update 
                   // continue;
                }
           
                //get users
                var userCollection = await GetUsersForAccount(resident.accountDetails.account, token);
                foreach (var user in userCollection.Users)
                {
                    if (user.UserDetails == null)
                    {
                        continue;
                    }

                    var userRef = new UserReference
                    {
                        //Id = Guid.NewGuid().ToString(),
                        //Vendor = vendor,
                        //VendorUserId = user.UserDetails.UserId.ToString(),
                        //UserType = user.UserDetails.UserType,
                        //Email = user.UserDetails.Email,
                        //UserName = user.UserDetails.UserName,
                        //CellPhoneNumber = user.UserDetails.CellPhoneNumber,
                        //Address = user.UserDetails.Address,
                        //FirstName = user.UserDetails.FirstName,
                        //LastName = user.UserDetails.LastName
                    };

                    //check if user has been existed
                    var userFound = existedUsers.Where(x => x.VendorUserId == userRef.VendorUserId && x.Vendor.Name == EventVendors.ESSENCE).FirstOrDefault();
                    if (userFound == default(UserReference))
                    {
                        //check if account has been added in the list
                        if (!userList.Any(x => x.VendorUserId == userRef.VendorUserId && x.Vendor.Name == EventVendors.ESSENCE))
                        {
                            userList.Add(userRef);
                        }
                    }
                    else
                    {
                        //update
                    }                   

                    //check if user/account has been existed
                    var accUserFound = existedAccountUsers.Where(x => x.UserId == userRef.Id && x.AccountId == account.Id).FirstOrDefault();
                    if (accUserFound == default(AccountUser))
                    {
                        var accUser = new AccountUser()
                        {
                            Account = account,
                            User = userRef
                        };
                        accountUserList.Add(accUser);
                    }
                }
            }
            return true;
        }

 
    }
}
