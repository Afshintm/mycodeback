using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    //this model is a refection of Identity user model
    // it is used by business models
    public class UserReference
    {
        //id is same as ApplicationUser id. 
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public ICollection<AccountUser> AccountUsers { get; set; } 
        public Vendor Vendor { get; set; }
        public string VendorUserId { get; set; }
    }
}
