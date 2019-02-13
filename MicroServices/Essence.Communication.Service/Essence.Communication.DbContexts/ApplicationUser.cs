﻿using Microsoft.AspNetCore.Identity;

namespace Essence.Communication.DbContexts
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(string userName) : base(userName) { }
    }
}