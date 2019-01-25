
using Microsoft.AspNetCore.Identity;
using System;

namespace MyIdentity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(string userName):base(userName) { }
    }
}
