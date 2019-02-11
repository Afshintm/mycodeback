using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.ValueObjects
{
    public interface IDetails
    {

    }

    public abstract class DeviceEventDetails : IDetails
    {
        public int DeviceId { get; set; }
        public int DeviceType { get; set; }
        public string DeviceDescription { get; set; }
    }

    //EssenceEvent 2003
    public class UnexpectedActivityDetails : DeviceEventDetails
    {
        public float Grade { get; set; }
    }

    //EssenceEvent 2201
    public class UnexpectedEntryExitDetails : DeviceEventDetails
    {
        public Period Period { get; set; }
    }

    //EssenceEvent  2103,2104
    public class StayHomeDetails : IDetails
    {
        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }
        public string EntryTime { get; set; }
    }

    //EssenceEvent 201/202
    public class PowerDetails : DeviceEventDetails
    {
        public string PowerFailureDuration { get; set; }
        public string PowerRestoredDuration { get; set; }
    }

    //EssenceEvent 203,204,205,206
    public class BatteryDetails : DeviceEventDetails
    {
        public int BatteryLevel { get; set; }
    }

    //EssenceEvent 705,706
    public class PanelStatusDetails : IDetails
    {
        public string LastContactTime { get; set; }
    }

    //EssenceEvent 2001
    public class FallAlertDetails : DeviceEventDetails
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DurationInRoom { get; set; }
    }

    //EssenceEvent 3,156
    public class EmergencyPanicDetails : DeviceEventDetails
    {
    }
}
