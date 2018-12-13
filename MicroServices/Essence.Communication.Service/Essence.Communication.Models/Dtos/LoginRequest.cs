using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class LoginRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
