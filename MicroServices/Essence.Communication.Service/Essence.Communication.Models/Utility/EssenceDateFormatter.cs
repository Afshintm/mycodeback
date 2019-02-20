using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Essence.Communication.Models.Utility
{
    public class EssenceDateFormatter
    {
        const string EssencePanelDateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        public DateTime? TryParsePanelTime(string dateAsText)
        {
            if (DateTime.TryParseExact(dateAsText, EssencePanelDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return null;
        }

        public string ToPanelTime(DateTime dt)
        {
            return dt.ToString(EssencePanelDateTimeFormat);
        }

        const string EssenceServerDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.sssZ";
        public DateTime? TryParseServerPanelTime(string dateAsText)
        {
            if (DateTime.TryParseExact(dateAsText, EssenceServerDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return null;
        }

        public string ToServerTime(DateTime dt)
        {
            return dt.ToString(EssenceServerDateTimeFormat);
        }

        const string EssenceBirthDateFormat = "yyyy-MM-dd";
        public string ToBirthDate(DateTime dt)
        {
            return dt.ToString(EssenceBirthDateFormat);
        }

        public DateTime? TryParseBirthDate(string dateAsText)
        {
            if (DateTime.TryParseExact(dateAsText, EssenceBirthDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
