using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Security.Claims;

namespace Essence.Communication.Models.IdentityModels
{
    public class IdentityUserProfile
    {
        public ApplicationUser User{get;set;}
        public IEnumerable <Claim> Claims { get; set; }
        public string Role { get; set; }

    }
}
