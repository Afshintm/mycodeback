using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{

    public class UsersForAccountResult
    {
        public User1[] users { get; set; }
        public bool Value { get; set; }
        public int Response { get; set; }
        public string ResponseDescription { get; set; }
        public object Message { get; set; }
    }

    public class User1
    {
        public Userdetails userDetails { get; set; }
        public Alertpreferences alertPreferences { get; set; }
        public Communicationmethods communicationMethods { get; set; }
    }

    public class Userdetails
    {
        public string careGiverType { get; set; }
        public bool mobileViewOnDesktop { get; set; }
        public int userId { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int languageId { get; set; }
        public string identificationNumber { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string cellPhoneNumber { get; set; }
        public object birthDate { get; set; }
        public string userName { get; set; }
        public object password { get; set; }
        public string address { get; set; }
        public string homePhone { get; set; }
        public Settings settings { get; set; }
        public int serviceType { get; set; }
        public string activeEmergencyCallNumber { get; set; }
    }
}
