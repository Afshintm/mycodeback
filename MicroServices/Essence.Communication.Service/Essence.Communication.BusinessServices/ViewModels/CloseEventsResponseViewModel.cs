using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices.ViewModels
{
    public class CloseEventsResponseViewModel
    {
        public List<string> ValidationResult { get; set; }
        public ResponseCode ResponseCode { get; set; }
        public string Description { get; set; }
    }

    public enum ResponseCode
    {
        OK = 0,
        AuthenticationFailed = 1,
        NoPermission = 2,
        Failed = 3
    }
}
