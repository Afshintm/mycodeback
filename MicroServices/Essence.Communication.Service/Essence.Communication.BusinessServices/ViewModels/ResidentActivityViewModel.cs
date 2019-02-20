using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices.ViewModels
{
    public class ResidentActivityViewModel
    {
        public string ResidentName { get; set; }
        public bool IsResidentCurrentlyHome { get; set; }
        public TimeSpan TotalSleep { get; set; }
        public int TotalRestroomTimes { get; set; }
        public TimeSpan TotalTimeOutOfHome { get; set; }

        public List<EventViewModel> Alerts { get; set; } //Urgent events
        public List<ActivityTypeViewModel> ActivityTypes { get; set; }
    }

    public class ActivityTypeViewModel
    {
        public string ActivityType { get; set; }
        public List<ActivityViewModel> Activities { get; set; }
    }

    public class ActivityViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool PassThreshold { get; set; }
    }
}
