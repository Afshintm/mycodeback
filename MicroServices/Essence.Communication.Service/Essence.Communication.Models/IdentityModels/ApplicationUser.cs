using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Essence.Communication.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string userName) : base(userName) { }

    }
}
