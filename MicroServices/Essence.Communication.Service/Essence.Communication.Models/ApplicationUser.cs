using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Essence.Communication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string userName) : base(userName) { }

        public ICollection<AccountUser> AccountUsers { get; set; }

    }
}
