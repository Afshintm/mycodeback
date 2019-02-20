using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices.ViewModels
{
    public class ResidentActivityViewModel
    {
        public string ResidentName { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime HasBennOutSince { get; set; }
        public TimeSpan TotalSleep { get; set; }
        public int TotalRestroomTimes { get; set; }
        public TimeSpan TotalTimeOutOfHome { get; set; }

        public List<EventViewModel> Alerts { get; set; } //Urgent events
        public List<EventViewModel> NonUrgentEvents { get; set; }
    }
}
