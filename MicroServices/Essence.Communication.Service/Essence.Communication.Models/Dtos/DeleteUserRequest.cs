using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class DeleteUserRequest
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string identificationNumber { get; set; }
    }
}
