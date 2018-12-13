using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class AddUserRequest
    {
        public User user { get; set; }
        public Panel panel { get; set; }
    }

    public class User
    {
        public string userType { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string identificationNumber { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string homePhone { get; set; }
        public string cellPhoneNumber { get; set; }
        public int languageId { get; set; }
        public int serviceType { get; set; }
        public Settings settings { get; set; }
        public string careGiverType { get; set; }
        public bool mobileViewOnDesktop { get; set; }
    }

    public class Settings
    {
        public Activeemergencycall activeEmergencyCall { get; set; }
    }

    public class Activeemergencycall
    {
        public bool enableCall { get; set; }
        public string phoneNumberType { get; set; }
        public object customPhoneNumber { get; set; }
    }

    public class Panel
    {
        public string account { get; set; }
        public string serviceProviderAccount { get; set; }
        public string panelSerialNumber { get; set; }
        public string serviceProviderSerialNumber { get; set; }
        public string simNumber { get; set; }
        public string dtmf { get; set; }
        public bool hasPets { get; set; }
        public string timeZone { get; set; }
        public string notes { get; set; }
        public Supportedfeatures supportedFeatures { get; set; }
        public PanelSettings settings { get; set; }
    }

    public class Supportedfeatures
    {
        public bool activeService { get; set; }
    }

    public class PanelSettings
    {
        public Activeemergencycall1 activeEmergencyCall { get; set; }
    }

    public class Activeemergencycall1
    {
        public string[] allowChangesBy { get; set; }
    }
}
