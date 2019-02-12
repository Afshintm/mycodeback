using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public class Account : Entity
    {
        private string AccountNumber { get; set; }

        public ICollection<EventBase> HSCEvents { get; set; } 
        public ICollection<AccountUser> AccountUsers { get; set; }

        public AccountGroup Group { get; set; }
        public Vendor Vendor { get; set; }
        public string VendorAccountId { get; set; }
    }

}
