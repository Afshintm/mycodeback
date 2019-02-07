using Essence.Communication.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Utility
{
    /// <summary>
    /// mapping between provider event oode and provider event name
    /// </summary>
    public interface IVendorEventList
    {
        string this[string key] { get; }
    }

    public class VendorEventList : IVendorEventList
    {
        private readonly Dictionary<string, string> _eventTypes = new Dictionary<string, string>();
        public VendorEventList()
        {
            _eventTypes.Add(EventTypes.Essence_EMERGENCY_PANIC_ALERM, $"{Vendor.Essence.ToString()}_3");
            _eventTypes.Add(EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED, $"{Vendor.Essence.ToString()}_156");
            _eventTypes.Add(EventTypes.Essence_POSSIBLE_FALL_ALERT, $"{Vendor.Essence.ToString()}_2001");
            _eventTypes.Add(EventTypes.Essence_DOOR_LEFT_OPEN_ALERT, $"{Vendor.Essence.ToString()}_2101");
            _eventTypes.Add(EventTypes.Essence_PANEL_ONLINE, $"{Vendor.Essence.ToString()}_705");
            _eventTypes.Add(EventTypes.Essence_PANEL_OFFLINE, $"{Vendor.Essence.ToString()}_706");
            _eventTypes.Add(EventTypes.Essence_LOW_BATTERY, $"{Vendor.Essence.ToString()}_203");
            _eventTypes.Add(EventTypes.Essence_LOW_BATTERY_RESET, $"{Vendor.Essence.ToString()}_204");
            _eventTypes.Add(EventTypes.Essence_EMPTY_BATTERY, $"{Vendor.Essence.ToString()}_205");
            _eventTypes.Add(EventTypes.Essence_BATTERY_RESTORED, $"{Vendor.Essence.ToString()}_206");
            _eventTypes.Add(EventTypes.Essence_MAINS_POWER_FAILURE, $"{Vendor.Essence.ToString()}_201");
            _eventTypes.Add(EventTypes.Essence_MAINS_POWER_RESTORED, $"{Vendor.Essence.ToString()}_202");
            _eventTypes.Add(EventTypes.Essence_WANDERING, $"{Vendor.Essence.ToString()}_2117");
            _eventTypes.Add(EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT, $"{Vendor.Essence.ToString()}_2201");
            _eventTypes.Add(EventTypes.Essence_EXTREME_INACTIVITY, $"{Vendor.Essence.ToString()}_2116");
            _eventTypes.Add(EventTypes.Essence_OUT_OF_HOME_ALERT, $"{Vendor.Essence.ToString()}_2103");
            _eventTypes.Add(EventTypes.Essence_BACK_AT_HOME_ALERT, $"{Vendor.Essence.ToString()}_2104");
        }

        public string this[string key]
        {
            get => _eventTypes[key];
        }
    }

    public static class EventTypes
    {
        public const string Essence_EMERGENCY_PANIC_ALERM = "Essence_EMERGENCY_PANIC_ALERM";
        public const string Essence_EMERGENCY_PANIC_ALERM_CANCELLED = "Essence_EMERGENCY_PANIC_ALERM_CANCELLED";
        public const string Essence_POSSIBLE_FALL_ALERT = "Essence_POSSIBLE_FALL_ALERT";
        public const string Essence_DOOR_LEFT_OPEN_ALERT = "Essence_DOOR_LEFT_OPEN_ALERT";
        public const string Essence_PANEL_ONLINE = "Essence_PANEL_ONLINE";
        public const string Essence_PANEL_OFFLINE = "Essence_PANEL_OFFLINE";
        public const string Essence_LOW_BATTERY = "Essence_LOW_BATTERY";
        public const string Essence_LOW_BATTERY_RESET = "Essence_LOW_BATTERY_RESET";
        public const string Essence_Long_Total_Sustained_Activity_Duration = "Essence_Long_Total_Sustained_Activity_Duration";
        public const string Essence_EMPTY_BATTERY = "Essence_EMPTY_BATTERY";
        public const string Essence_BATTERY_RESTORED = "Essence_BATTERY_RESTORED";
        public const string Essence_MAINS_POWER_FAILURE = "Essence_MAINS_POWER_FAILURE";
        public const string Essence_MAINS_POWER_RESTORED = "Essence_MAINS_POWER_RESTORED";
        public const string Essence_NO_PRESENCE = "Essence_NO_PRESENCE";
        public const string Essence_WANDERING = "Essence_WANDERING";
        public const string Essence_PRESENCE = "Essence_PRESENCE";
        public const string Essence_UNEXPECTED_ENTRY_OR_EXIT = "Essence_UNEXPECTED_ENTRY_OR_EXIT";
        public const string Essence_EXTREME_INACTIVITY = "Essence_EXTREME_INACTIVITY";
        public const string Essence_OUT_OF_HOME_ALERT = "Essence_OUT_OF_HOME_ALERT";
        public const string Essence_BACK_AT_HOME_ALERT = "Essence_BACK_AT_HOME_ALERT";
    }
}
