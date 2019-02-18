using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{

    public class GetUsersResult : ResponseBase
    {
        public GetUsersResult() { }
        public GetUsersResult(ResponseBase response) : base(response) { }

        public UserResult[] users { get; set; } 
    }

    public class UserResult
    {
        public Paneldetails panelDetails { get; set; }
        public Accountdetails accountDetails { get; set; }
        public string careGiverType { get; set; }
        public DateTime? birthDate { get; set; }
        public string address { get; set; }
        public string homePhone { get; set; }
        public string cellPhoneNumber { get; set; }
        public int languageId { get; set; }
        public int userId { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string identificationNumber { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public object servicePackage { get; set; }
    }

    public class Paneldetails
    {
        public string simNumber { get; set; }
        public string panelSerialNumber { get; set; }
        public string serviceProviderSerialNumber { get; set; }
        public int dtmf { get; set; }
        public bool supportDeviceSync { get; set; }
    }

    public class Accountdetails
    {
        public string account { get; set; }
        public object activationStatus { get; set; }
        public bool hasPets { get; set; }
        public string notes { get; set; }
        public string serviceProviderAccountNumber { get; set; }
        public string servicePackageCode { get; set; }
        public string timeZone { get; set; }
        public bool enableActiveService { get; set; }
        public object complianceNotificationInHours { get; set; }
        public object complianceNotificationEnabled { get; set; }
    }

}
