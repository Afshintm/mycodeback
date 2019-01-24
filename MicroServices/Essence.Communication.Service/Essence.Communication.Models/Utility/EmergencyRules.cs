

using Essence.Communication.Models.ValueObjects;
using System.Collections.Generic;

namespace Essence.Communication.Models.Utility
{
    public interface IEventEmergencyRules
    {
        EmergencyCategory this[string key] { get; }
    }
    public class EmergencyRules  : IEventEmergencyRules
    {
        private readonly IVendorEventList _eventList;
        private Dictionary<string, EmergencyCategory> _rules = new Dictionary<string, EmergencyCategory>();
        public EmergencyRules(IVendorEventList eventList)
        {
            _eventList = eventList;
            _rules.Add(_eventList[EventTypes.Essence_EMERGENCY_PANIC_ALERM], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_POSSIBLE_FALL_ALERT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_DOOR_LEFT_OPEN_ALERT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_PANEL_ONLINE], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_PANEL_OFFLINE], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_LOW_BATTERY], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_LOW_BATTERY_RESET], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_EMPTY_BATTERY], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_BATTERY_RESTORED], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_MAINS_POWER_FAILURE], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_MAINS_POWER_RESTORED], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_WANDERING], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_NO_ACTIVITY], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_ACTIVITY_RESUMED], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_EXTREME_INACTIVITY], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_UNUSUAL_ACTIVITY_ALERT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_OUT_OF_HOME_ALERT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
            _rules.Add(eventList[EventTypes.Essence_BACK_AT_HOME_ALERT], new EmergencyCategory { Level = Enums.EmergencyLevels.High, Description = "" });
        }

        public EmergencyCategory this[string key]
        {
            get => _rules[key];
        }
    }
}
