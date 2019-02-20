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
using Essence.Communication.Models.Dtos;

namespace Essence.Communication.BusinessServices
{
    public interface IIdentityUserProfileService
    {
        Task<bool> TryAddUserProfile(ApplicationUser user);
        Task<bool> TryAddUserClaims(ApplicationUser user, IEnumerable<Claim> claims);
        Task<bool> TryAddUserRoles(ApplicationUser user, string role);

        Task AddBatchUsers(List<IdentityUserProfile> users );
    }

    public class IdentityUserProfileService : IIdentityUserProfileService
    {
        private const string tempPaassword = "Pass123$";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityUserProfileService (UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           _userManager = userManager;
           _roleManager = roleManager;
        }

        public async Task<bool> TryAddUserProfile(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user, tempPaassword);
            if (!result.Succeeded)
            {
                //log
                return false;
            }
            
            return true;
        }

        public async Task<bool> TryAddUserClaims(ApplicationUser user, IEnumerable<Claim> claims)
        {
            var result = await _userManager.AddClaimsAsync(user, claims);
            if (!result.Succeeded)
            {
                //log
                return false;
            }

            return true;
        }

        public async Task<bool> TryAddUserRoles(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                //log
                return false;
            }

            return true;
        }

        public async Task AddBatchUsers(List<IdentityUserProfile> users)
        {
            foreach(var user in users)
            {
                if (user.User == default(ApplicationUser))
                {
                    continue;
                }

                try
                {
                    if (await TryAddUserProfile(user.User))
                    {
                        await TryAddUserClaims(user.User, user.Claims);
                        await TryAddUserRoles(user.User, user.Role);
                    }
                }
                catch(Exception ex)
                {
                    //log user can not be created
                }
            }
        }

        private string MapRoles(string userType)
        {
            switch (userType.ToUpper())
            {
                case "CareGiver":
                    return "CaregiverRole";
                case "StandardCareGiver":
                    return "CaregiverRole";
                case "MasterCareGiver":
                    return "CaregiverRole";
                case "Administrator":
                    return "AdminRole";
                default:
                    return "ResidentRole";
            }
        }

    }
}
