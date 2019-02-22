using Essence.Communication.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    //this model is a refection of Identity user model
    // it is used by business models
    public class UserReference
    {
        public UserReference()
        {
        }
        //id is same as ApplicationUser id. 
        public string Id { get;   set; }
        public virtual string UserName { get;   set; }
        public string UserType { get;  set; }
        public  string Email { get;   set; }
        public string CellPhoneNumber { get;  set; }
        public string Gender { get;  set; }
        public string Address { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        public ICollection<AccountUser> AccountUsers { get; set; } 
        public Vendor Vendor { get; set; }
        public string VendorUserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
