using BuildingBlocks.EventBus.Events;
using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    //Evernt 2117,2152,2153,2201,2116,2003
    public class ActivityDetails: BaseDetails
    {
        public string Since { get; set; } 
        public string Period { get; set; }
        public int? Grade { get; set; }
    }

    //Evernt  2103,2104
    public class StayHomeDetails : BaseDetails
    {
        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }
        public string EntryTime { get; set; }
    }

    //Evernt 201/202
    public class PowerDetails: BaseDetails
    {
        public string PowerFailureDuration { get; set; }
        public string PowerRestoredDuration { get; set; }
    }

    //Evernt 203,204,205,206
    public class BatteryDetails : BaseDetails
    {
        public int BatteryLevel{ get; set; }
    }

    //Evernt 705,706
    public class PanelStatusDetails: BaseDetails
    {
        public string LastContactTime { get; set; }
    }

    //Evernt 2101
    public class DoorStatusDetails: BaseDetails
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DoorOpenDuration { get; set; }
        public string DoorOpentime { get; set; }
    }

    //Evernt 2001
    public class FallAlertDetails : BaseDetails
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DurationInRoom { get; set; }
    }

    //Evernt 3,156
    public class EmergencyPanicDetails: BaseDetails
    {
        public int? RadioLevel { get; set; }
        public int? Trigger { get; set; }
        public int? ConflidenceLevel { get; set; }
    }
     

}
