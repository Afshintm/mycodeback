using BuildingBlocks.EventBus.Events;
using System.Collections.Generic;

namespace Essence.Communication.BusinessServices.Model
{
    public abstract class BaseDetails
    {
        public int? DeviceId { get; set; }
        public int? DeviceType { get; set; }
        public string DeviceDescription { get; set; }
    }

    public class Period
    {
        public bool Is24Hours { get; set; }
        //HH:mm
        public string PeriodStartTime { get; set; }
        //HH:mm
        public string PeriodEndTime { get; set; }
    }

    //Evernt 2003
    public class UnexpectedActivityDetails: BaseDetails
    {
        public int Grade { get; set; }
    }

    //Evernt 2201
    public class UnexpectedEntryExitDetails : BaseDetails
    {
        public Period Period { get; set; }
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

    //Evernt 2001
    public class FallAlertDetails : BaseDetails
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DurationInRoom { get; set; }
    }

    //Evernt 3,156
    public class EmergencyPanicDetails: BaseDetails
    {
    }
     

}
