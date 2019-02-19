using System.Collections.Generic;

namespace Essence.Communication.Models.Utility
{
    /// <summary>
    /// mapping between HSC event oode and  event name
    /// </summary>
    public interface IEventCodeList
    {
        string this[string key] { get; }
    }

    public class HSCEventCodeList : IEventCodeList
    {
        private readonly Dictionary<string, string> _eventTypes = new Dictionary<string, string>();
        public HSCEventCodeList()
        {
            InitializeEssenceEventCodes();
        }

        public string this[string key]
        {
            get => _eventTypes[key];
        }

        private void InitializeEssenceEventCodes()
        {
            _eventTypes.Add(EventTypes.Essence_EMERGENCY_PANIC_ALERM, HSCEventHelper.GetEventCodeFromEssence("3"));
            _eventTypes.Add(EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED, HSCEventHelper.GetEventCodeFromEssence("156"));
            _eventTypes.Add(EventTypes.Essence_POSSIBLE_FALL_ALERT, HSCEventHelper.GetEventCodeFromEssence("2001"));
            _eventTypes.Add(EventTypes.Essence_DOOR_LEFT_OPEN_ALERT, HSCEventHelper.GetEventCodeFromEssence("2101"));
            _eventTypes.Add(EventTypes.Essence_PANEL_ONLINE, HSCEventHelper.GetEventCodeFromEssence("705"));
            _eventTypes.Add(EventTypes.Essence_PANEL_OFFLINE, HSCEventHelper.GetEventCodeFromEssence("706"));
            _eventTypes.Add(EventTypes.Essence_LOW_BATTERY, HSCEventHelper.GetEventCodeFromEssence("203"));
            _eventTypes.Add(EventTypes.Essence_LOW_BATTERY_RESET, HSCEventHelper.GetEventCodeFromEssence("204"));
            _eventTypes.Add(EventTypes.Essence_EMPTY_BATTERY, HSCEventHelper.GetEventCodeFromEssence("205"));
            _eventTypes.Add(EventTypes.Essence_BATTERY_RESTORED, HSCEventHelper.GetEventCodeFromEssence("206"));
            _eventTypes.Add(EventTypes.Essence_MAINS_POWER_FAILURE, HSCEventHelper.GetEventCodeFromEssence("201"));
            _eventTypes.Add(EventTypes.Essence_MAINS_POWER_RESTORED, HSCEventHelper.GetEventCodeFromEssence("202"));
            _eventTypes.Add(EventTypes.Essence_WANDERING, HSCEventHelper.GetEventCodeFromEssence("2117"));
            _eventTypes.Add(EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT, HSCEventHelper.GetEventCodeFromEssence("2201"));
            _eventTypes.Add(EventTypes.Essence_EXTREME_INACTIVITY, HSCEventHelper.GetEventCodeFromEssence("2116"));
            _eventTypes.Add(EventTypes.Essence_OUT_OF_HOME_ALERT, HSCEventHelper.GetEventCodeFromEssence("2103"));
            _eventTypes.Add(EventTypes.Essence_BACK_AT_HOME_ALERT, HSCEventHelper.GetEventCodeFromEssence("2104"));
            _eventTypes.Add(EventTypes.Essence_LONG_TOTAL_SUSTAINED_ACTIVITY_DURATION, HSCEventHelper.GetEventCodeFromEssence("2114"));
            _eventTypes.Add(EventTypes.Essence_NO_PRESENCE, HSCEventHelper.GetEventCodeFromEssence("2105"));
            _eventTypes.Add(EventTypes.Essence_PRESENCE, HSCEventHelper.GetEventCodeFromEssence("2107"));
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
        public const string Essence_LONG_TOTAL_SUSTAINED_ACTIVITY_DURATION = "Essence_Long_Total_Sustained_Activity_Duration";
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
