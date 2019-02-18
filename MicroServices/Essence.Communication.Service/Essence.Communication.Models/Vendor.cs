using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public class Vendor : Entity
    {
        private string _name;
        public Vendor(string name)
        {
            _name = name;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        public ICollection<EssenceEventObjectStructure> VendorEvents { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<UserReference> Users { get; set; }
    }
}
