using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    /// <summary>
    /// mapping between provider event oode and provider event name
    /// </summary>
    public interface IProviderEventTypesManager
    {
        int this[string key] { get; }
    }

    public class EssenceEventTypesManager : IProviderEventTypesManager
    {
        private readonly Dictionary<string, int> _eventTypes = new Dictionary<string, int>();
        public EssenceEventTypesManager()
        {
            _eventTypes.Add(EventTypes.EMERGENCY_PANIC_ALERM, 3);
            _eventTypes.Add(EventTypes.EMERGENCY_PANIC_ALERM_CANCELLED, 156);
            _eventTypes.Add(EventTypes.POSSIBLE_FALL_ALERT, 2001);
            _eventTypes.Add(EventTypes.DOOR_LEFT_OPEN_ALERT, 2101);
            _eventTypes.Add(EventTypes.PANEL_ONLINE, 705);
            _eventTypes.Add(EventTypes.PANEL_OFFLINE, 706);
            _eventTypes.Add(EventTypes.LOW_BATTERY, 203);
            _eventTypes.Add(EventTypes.LOW_BATTERY_RESET, 204);
            _eventTypes.Add(EventTypes.EMPTY_BATTERY, 205);
            _eventTypes.Add(EventTypes.BATTERY_RESTORED, 206);
            _eventTypes.Add(EventTypes.MAINS_POWER_FAILURE, 201);
            _eventTypes.Add(EventTypes.MAINS_POWER_RESTORED, 202);
            _eventTypes.Add(EventTypes.WANDERING, 2117);
            _eventTypes.Add(EventTypes.NO_ACTIVITY, 2152);
            _eventTypes.Add(EventTypes.ACTIVITY_RESUMED, 2153);
            _eventTypes.Add(EventTypes.UNEXPECTED_ENTRY_OR_EXIT, 2201);
            _eventTypes.Add(EventTypes.EXTREME_INACTIVITY, 2116);
            _eventTypes.Add(EventTypes.UNUSUAL_ACTIVITY_ALERT, 2003);
            _eventTypes.Add(EventTypes.OUT_OF_HOME_ALERT, 2103);
            _eventTypes.Add(EventTypes.BACK_AT_HOME_ALERT, 2104);
        }

        public int this[string key]
        {
            get => _eventTypes[key];
        }
    }

    public static class EventTypes
    {
        public const string EMERGENCY_PANIC_ALERM = "EMERGENCY_PANIC_ALERM";
        public const string EMERGENCY_PANIC_ALERM_CANCELLED = "EMERGENCY_PANIC_ALERM_CANCELLED";
        public const string POSSIBLE_FALL_ALERT = "POSSIBLE_FALL_ALERT";
        public const string DOOR_LEFT_OPEN_ALERT = "DOOR_LEFT_OPEN_ALERT";
        public const string PANEL_ONLINE = "PANEL_ONLINE";
        public const string PANEL_OFFLINE = "PANEL_OFFLINE";
        public const string LOW_BATTERY = "LOW_BATTERY";
        public const string LOW_BATTERY_RESET = "LOW_BATTERY_RESET";
        public const string EMPTY_BATTERY = "EMPTY_BATTERY";
        public const string BATTERY_RESTORED = "BATTERY_RESTORED";
        public const string MAINS_POWER_FAILURE = "MAINS_POWER_FAILURE";
        public const string MAINS_POWER_RESTORED = "MAINS_POWER_RESTORED";
        public const string WANDERING = "WANDERING";
        public const string NO_ACTIVITY = "NO_ACTIVITY";
        public const string ACTIVITY_RESUMED = "ACTIVITY_RESUMED";
        public const string UNEXPECTED_ENTRY_OR_EXIT = "UNEXPECTED_ENTRY_OR_EXIT";
        public const string EXTREME_INACTIVITY = "EXTREME_INACTIVITY";
        public const string UNUSUAL_ACTIVITY_ALERT = "UNUSUAL_ACTIVITY_ALERT";
        public const string OUT_OF_HOME_ALERT = "OUT_OF_HOME_ALERT";
        public const string BACK_AT_HOME_ALERT = "BACK_AT_HOME_ALERT";
    }
}
