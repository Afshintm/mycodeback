﻿using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models
{
    public class AccountUser : Entity
    {
        public string AccountId {get;set;}
        public string UserId { get; set; }

        public UserReference User { get; set; }
        public Account Account { get; set; }
        public CareGiverType CareGiverType { get; set; }
    } 
}
