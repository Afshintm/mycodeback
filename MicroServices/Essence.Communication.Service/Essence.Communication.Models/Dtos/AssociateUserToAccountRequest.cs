using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class AssociateUserToAccountRequest
    {
        public string accountIdentifier { get; set; }
        public bool IsAdd { get; set; }
        public int panelId { get; set; }
        public string userName { get; set; }
        public int userId { get; set; }
        public string careGiverType { get; set; }
        public Alertpreferences alertPreferences { get; set; }
        public Communicationmethods communicationMethods { get; set; }
    }
}
