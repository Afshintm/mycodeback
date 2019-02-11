using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Extensions
{
    public static class VendorEventExtensions
    {
        public static string GetVendorEventCode( this VendorEvent vEvent, string code)
        {
            return $"{vEvent.Vendor.ToString()}_{code}";
        }
    }
}
