using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public class Account : Entity
    {
        public ICollection<EventBase> HSCEvents { get; set; } 
        public ICollection<AccountUser> AccountUsers { get; set; }
        public AccountGroup Group { get; set; }

        //when have multiple vendors the 3 below should move to a mapping table
        public Vendor Vendor { get; set; }
        //accont id input when registering the account in vendor system
        public string AccountNo { get; set; }
        public string VendorAccountNo { get; set; }
    }

}
