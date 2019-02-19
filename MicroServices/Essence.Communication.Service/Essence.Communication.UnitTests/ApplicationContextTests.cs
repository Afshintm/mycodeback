using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.IdentityModels;
using Essence.Communication.Models.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Essence.Communication.UnitTests
{
    public class ApplicationContextTests
    {
        private List<Account> CreateFakeAccounts()
        { 
            return new List<Account>()
            {
                new Account(){ VendorAccountNo = "VenderAccount1"},
                new Account(){ VendorAccountNo = "VenderAccount2"},
                new Account() { VendorAccountNo = "VenderAccount3" }
            };
        }

        private List<ApplicationUser> CreateFakeUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser(){UserName  = "userName1", Email = "user1@gmail.com",
                    UserRef = new UserReference{UserName = "userName1", Email = "user1@gmail.com" } },//, Id = Guid.NewGuid().ToString(), CellPhoneNumber = "123"},
                new ApplicationUser(){UserName  = "userName2", Email = "user2@gmail.com",
                UserRef = new UserReference{UserName = "userName2", Email = "user2@gmail.com" } },//, Id = Guid.NewGuid().ToString(), CellPhoneNumber = "1223"},
                new ApplicationUser(){UserName  = "userName3", Email = "user3@gmail.com",
                UserRef = new UserReference{UserName = "userName3", Email = "user3@gmail.com" } },//, Id = Guid.NewGuid().ToString(), CellPhoneNumber = "1223"}
            };
        }

        private List<Vendor> CreateFakeVendors()
        {
            return new List<Vendor>()
            {
                new Vendor("Vendor1"),
                new Vendor("Vendor2"),
                new Vendor("Vendor3")
            };
        }

        private List<AccountUser> CreateFakeAccountUsers(List<Account> accounts, List<UserReference> users)
        {
            return new List<AccountUser>()
            {
                new AccountUser() { AccountId = accounts[0].Id, UserId = users[0].Id },
                new AccountUser() { AccountId = accounts[1].Id, UserId = users[1].Id },
                new AccountUser() { AccountId = accounts[2].Id, UserId = users[2].Id }
            };
        }

        [Fact]
        public void Account_AddAccountsOk()
        {
            //arrange
            var options = EFTestInMemoryHelper.CreateContextOptions<ApplicationDbContext>();

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                //action
                var testList = CreateFakeAccounts();
                context.Accounts.AddRange(testList);
                context.SaveChanges();

                //assert
                var result = context.Accounts.ToList();
                Assert.True(result.Count == 3);
                Assert.True(!string.IsNullOrEmpty(result[0].Id));
                Assert.True(result[0].CreatedDate.Date == DateTime.UtcNow.Date);
                Assert.True(result[0].VendorAccountNo == testList[0].VendorAccountNo);
            }
        }

        [Fact]
        public void Vendor_VendorSeedDataCreated()
        {
            //arrange
            var options = EFTestInMemoryHelper.CreateContextOptions<ApplicationDbContext>();

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                //action
                var testList = CreateFakeVendors(); 
                context.SaveChanges();

                //assert
                var result = context.Vendors.ToList();
                Assert.True(result.Count == 1, "count is not 1");
                Assert.True(result[0].Name == EventVendors.ESSENCE, "seed data name is wrong"); 
            }
        }

        [Fact]
        public void Vendor_AddVendorsOk()
        {
            //arrange
            var options = EFTestInMemoryHelper.CreateContextOptions<ApplicationDbContext>();

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                //action
                var testList = CreateFakeVendors();
                context.Vendors.AddRange(testList);
                context.SaveChanges();

                //assert
                var result = context.Vendors.ToList();

                //test count add seed data
                Assert.True(result.Count == testList.Count + 1, "count is not 3");
                Assert.True(!string.IsNullOrEmpty(result[0].Id), "result is null");
                Assert.True(result[0].CreatedDate.Date == DateTime.UtcNow.Date, "datetime is not matched");
                Assert.True(result.Where( t => t.Name == testList[0].Name).Count() == 1, "Specific Name is not found");
            }
        }

        [Fact]
        public void UserReference_AddUsersOk()
        {
            //arrange
            var options = EFTestInMemoryHelper.CreateContextOptions<ApplicationDbContext>(); 
             
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                //action
                var testList = CreateFakeUsers();
                context.Users.AddRange(testList);
                
                context.SaveChanges();

                //assert
                var result = context.Users.ToList();
                Assert.True(result.Count == 3);
                Assert.True(!string.IsNullOrEmpty(result[0].Id));  
            }
        }

        [Fact]
        public void AccountUser_GetUserRefOk()
        {
            //arrange
            var options = EFTestInMemoryHelper.CreateContextOptions<ApplicationDbContext>();

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                //action
                var testList = CreateFakeUsers();
                context.Users.AddRange(testList);

                context.SaveChanges();

                //assert
                var result = context.UserRef.ToList();
                Assert.True(result.Count == 3);
                Assert.True(!string.IsNullOrEmpty(result[0].Id));
            }
        }

    }
}
