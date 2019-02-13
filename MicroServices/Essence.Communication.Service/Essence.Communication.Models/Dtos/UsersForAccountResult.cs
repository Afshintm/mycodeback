using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{

    public class UsersForAccountResult
    {
        public UserProfile[] Users { get; set; }
        public bool Value { get; set; }
        public int Response { get; set; }
        public string ResponseDescription { get; set; }
        public object Message { get; set; }
    }

    public class UserProfile
    {
        public Userdetails UserDetails { get; set; }
        public Alertpreferences AlertPreferences { get; set; }
        public Communicationmethods CommunicationMethods { get; set; }
    }

    public class Userdetails
    {
        public string CareGiverType { get; set; }
        public bool MobileViewOnDesktop { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int lLanguageId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
        public object BirthDate { get; set; }
        public string UserName { get; set; }
        public object Password { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public Settings Settings { get; set; }
        public int ServiceType { get; set; }
        public string AtiveEmergencyCallNumber { get; set; }
    }
}
