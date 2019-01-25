using BuildingBlocks.EventBus.Events;
using Essence.Communication.Models.ValueObjects;
using System.Collections.Generic;

namespace Essence.Communication.BusinessServices.ViewModel
{
    public interface IDetailsViewModel
    {
    }

    public abstract class DeviceEventDetailsViewModel : IDetailsViewModel
    {
        public int DeviceId { get; set; }
        public int DeviceType { get; set; }
        public string DeviceDescription { get; set; }
    }
    
    public class UnexpectedActivityDetailsViewModel : DeviceEventDetailsViewModel
    {
        public float Grade { get; set; }
    }
    
    public class UnexpectedEntryExitDetailsViewModel : DeviceEventDetailsViewModel
    {
        public bool Is24Hours { get; set; }
        //HH:mm
        public string PeriodStartTime { get; set; }
        //HH:mm
        public string PeriodEndTime { get; set; }
    }
    
    public class StayHomeDetailsViewModel : IDetailsViewModel
    {
        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }
        public string EntryTime { get; set; }
    }
    
    public class PowerDetailsViewModel : DeviceEventDetailsViewModel
    {
        public string PowerFailureDuration { get; set; }
        public string PowerRestoredDuration { get; set; }
    }
    
    public class BatteryDetailsViewModel : DeviceEventDetailsViewModel
    {
        public int BatteryLevel { get; set; }
    }
    
    public class PanelStatusDetailsViewModel : IDetailsViewModel
    {
        public string LastContactTime { get; set; }
    }
    
    public class FallAlertDetailsViewModel : DeviceEventDetailsViewModel
    {
        public int Activitytype { get; set; } //TODO: enum
        public string DurationInRoom { get; set; }
    }
    
    public class EmergencyPanicDetailsViewModel : DeviceEventDetailsViewModel
    {
    }


}
