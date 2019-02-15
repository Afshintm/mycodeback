using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Essence.Communication.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string userName) : base(userName) { }

        [NotMapped]
        public string UserType { get; set; }

        public ICollection<IdentityUserRole<string>> IdentityUserRoles { get; set; }


    }
}
