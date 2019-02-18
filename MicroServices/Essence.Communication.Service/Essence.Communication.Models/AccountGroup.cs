using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public class AccountGroup : Entity
    {
        public ICollection<Account> Accounts { get; set; } 
        public string Name { get; set; }
    }

}
