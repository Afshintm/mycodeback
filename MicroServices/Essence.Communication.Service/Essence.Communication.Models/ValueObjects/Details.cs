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

    //Evernt 2003
    public class UnexpectedActivityDetails : DeviceEventDetails
    {
        public int Grade { get; set; }
    }

    //Evernt 2201
    public class UnexpectedEntryExitDetails : DeviceEventDetails
    {
        public Period Period { get; set; }
    }

    //Evernt  2103,2104
    public class StayHomeDetails : IDetails
    {
        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }
        public string EntryTime { get; set; }
    }

    //Evernt 201/202
    public class PowerDetails : DeviceEventDetails
    {
        public string PowerFailureDuration { get; set; }
        public string PowerRestoredDuration { get; set; }
    }

    //Evernt 203,204,205,206
    public class BatteryDetails : DeviceEventDetails
    {
        public int BatteryLevel { get; set; }
    }

    //Evernt 705,706
    public class PanelStatusDetails : IDetails
    {
        public string LastContactTime { get; set; }
    }

    //Evernt 2001
    public class FallAlertDetails : DeviceEventDetails
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DurationInRoom { get; set; }
    }

    //Evernt 3,156
    public class EmergencyPanicDetails : DeviceEventDetails
    {
    }
}
