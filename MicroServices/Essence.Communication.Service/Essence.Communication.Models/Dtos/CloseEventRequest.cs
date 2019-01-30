using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class CloseEventsRequest
    {
        public int AccountNumber { get; set; }
        public bool OverrideRequesterName { get; set; }
        public int CloseReason { get; set; } //TODO: do we need to record essence closeReason enum?
        public int HandingConclusion { get; set; } //TODO: do we need to record essence HandingConclusion enum?
        public string HandlingDescription { get; set; }
        public int SessionData { get; set; }
        public CloseEventsFilters Filter { get; set; }
        public CloseEventsTimeFilter MinimumTime { get; set; }
        public CloseEventsTimeFilter MaximumTime { get; set; }
    }

    public class CloseEventsTimeFilter
    {
        public DateTime Value { get; set; }
    }

    public class CloseEventsFilters
    {
        public List<EventHandlingEventTypeFilterEnum> ActiveEmergencyCall { get; set; }
        public List<Guid> Ids { get; set; }
    }

    public enum EventHandlingEventTypeFilterEnum
    {
        Activity = 1,
        Acute = 2,
        Video = 1,
        Technical = 4
    }


}
