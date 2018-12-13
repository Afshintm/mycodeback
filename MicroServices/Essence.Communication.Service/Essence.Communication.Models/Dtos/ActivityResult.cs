using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class ActivityResult
    {
        public bool Value { get; set; }
        public int Response { get; set; }
        public string ResponseDescription { get; set; }
        public Activitytype[] activityTypes { get; set; }
        public Missinginformation[] missingInformation { get; set; }
    }

    public class Activitytype
    {
        public string activityType { get; set; }
        public Activity[] activities { get; set; }
    }

    public class Activity
    {
        public object startTime { get; set; }
        public object endTime { get; set; }
        public bool passThreshold { get; set; }
    }

    public class Missinginformation
    {
        public string reason { get; set; }
        public Interval[] intervals { get; set; }
    }

    public class Interval
    {
        public DateTime startTime { get; set; }
        public DateTime? endTime { get; set; }
        public string previousActivity { get; set; }
    }
}
