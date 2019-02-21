using Essence.Communication.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.DbContexts
{
    public interface IIdentityUserContext
    {
         DbSet<ApplicationUser> Users { get; set; }
         DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
         DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        DbSet<IdentityUserToken<string>> UserTokens { get; set; }
         DbSet<IdentityUserRole<string>> UserRoles { get; set; }
         DbSet<IdentityRole> Roles { get; set; }
        DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }
    }
}
