using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Utility
{
    public static class HSCEventHelper
    {
        /// <summary>
        /// get event
        /// </summary>
        public static string GetEventCodeFromEssence(string essenceCode)
        {
            return $"{ EventVendors.ESSENCE}_{essenceCode}";
        }
    }
}
