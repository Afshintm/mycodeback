using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Essence.Communication.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {
            Id = Guid.NewGuid().ToString();
            this.UserRef = new UserReference() { Id = Id } ;
        }

        public ApplicationUser(string userName) : base(userName) { }

        public override string Email { get ; set ; }
        public UserReference UserRef { get; set; }
        public string UserType { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
