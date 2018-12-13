using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class DisassociateUserFromAccountRequest
    {
        public string accountIdentifier { get; set; }
        public int panelId { get; set; }
        public string userName { get; set; }
        public int userId { get; set; }
    }
}
