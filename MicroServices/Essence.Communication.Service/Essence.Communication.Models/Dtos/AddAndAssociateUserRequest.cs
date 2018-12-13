using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{

    public class AddAndAssociateUserRequest
    {
        public string account { get; set; }
        public object panelId { get; set; }
        public string careGiverType { get; set; }
        public User user { get; set; }
        public Alertpreferences alertPreferences { get; set; }
        public Communicationmethods communicationMethods { get; set; }
    }

    public class Alertpreferences
    {
        public bool sos { get; set; }
        public bool abnormalActivity { get; set; }
        public bool smoke { get; set; }
        public bool waterLeakage { get; set; }
        public bool possibleFall { get; set; }
        public bool doorOpen { get; set; }
        public bool notAtHome { get; set; }
        public bool presence { get; set; }
        public bool excessiveActivity { get; set; }
        public bool lowActivity { get; set; }
        public bool unexpectedEntryExit { get; set; }
        public bool extremeTemperature { get; set; }
        public bool technical { get; set; }
    }

    public class Communicationmethods
    {
        public bool sendReportsBySMS { get; set; }
        public bool sendReportsByEmail { get; set; }
        public bool sendAlertsBySMS { get; set; }
        public bool sendAlertsByEmail { get; set; }
    }

}
