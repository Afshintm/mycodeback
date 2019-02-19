using Essence.Communication.DbContexts;
using Essence.Communication.Models.IdentityModels;
using Services.Utilities.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Essence.Communication.Models;
using System.Security.Claims;

namespace Essence.Communication.BusinessServices
{
    public interface IIdentityUserProfileService
    {
        Task<bool> UpdateUserProfiles(IEnumerable<UserReference> users);
    }

    public class IdentityUserProfileService : IIdentityUserProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityUserProfileService (UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           _userManager = userManager;
           _roleManager = roleManager;
        }

        public async Task<bool> UpdateUserProfiles(IEnumerable<UserReference> users)
        {
           var appUser = new ApplicationUser { PhoneNumber = "11111", Email = "ttt@gggg.com", UserName = "Test1eee111",
               CellPhoneNumber = "111333111"
               , UserRef = new UserReference { CellPhoneNumber = "111333111", Email = "ttt@gggg.com", UserName = "Test1eee111" }
           
           };

           // var a = await _roleManager.CreateAsync(new IdentityRole("MyTestRole"));
         //  if (!a.Succeeded)
           // {

           // }

            var result = await _userManager.CreateAsync(appUser, "Pass123$");
            if (!result.Succeeded )
            {
                return false;
            }
            result = await _userManager.AddClaimsAsync(appUser, new Claim[] {
                             new Claim("name", "app2 test"),
                            new Claim("given_name", "app2"),
                            new Claim("family_name", "test"),
                            new Claim("TestClaim", "testClaim"),
                });

            if (!result.Succeeded)
            {
                return false;
            }
            result =await _userManager.AddToRoleAsync(appUser, "MyTestRole");

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
            //todo add role not belongs to existing role
        }

        
    }
}
