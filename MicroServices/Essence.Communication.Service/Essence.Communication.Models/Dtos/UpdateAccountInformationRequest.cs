using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class UpdateAccountInformationRequest
    {
        public int accountNumber { get; set; }
        public int panelId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string homePhone { get; set; }
        public bool hasPets { get; set; }
        public string installationNotes { get; set; }
        public string simNumber { get; set; }
        public string panelSerialNumber { get; set; }
        public string serviceProviderSerialNumber { get; set; }
        public string serviceProviderAccountNumber { get; set; }
        public string dtmfCode { get; set; }
        public string timeZone { get; set; }
        public Supportedfeatures supportedFeatures { get; set; }
        public Settings settings { get; set; }
    }
}
