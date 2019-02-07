

using Essence.Communication.Models.Enums;
using Essence.Communication.Models.ValueObjects;
using System.Collections.Generic;

namespace Essence.Communication.Models.Utility
{
    public interface IEventAlertRules
    {
        AlertType this[string key] { get; }
    }

    /// <summary>
    /// map event's alter type against event code (i.e. vendorName_venderCode)
    /// </summary>
    public class AlertTypeRules  : IEventAlertRules
    {
        private readonly IVendorEventList _eventList;
        private Dictionary<string, AlertType> _rules = new Dictionary<string, AlertType>();
        public AlertTypeRules(IVendorEventList eventList)
        {
            _eventList = eventList;
            _rules.Add(eventList[EventTypes.Essence_BACK_AT_HOME_ALERT], AlertType.Event);
            _rules.Add(eventList[EventTypes.Essence_BATTERY_RESTORED], AlertType.Event);
            _rules.Add(eventList[EventTypes.Essence_DOOR_LEFT_OPEN_ALERT], AlertType.Alert);
            _rules.Add(_eventList[EventTypes.Essence_EMERGENCY_PANIC_ALERM], AlertType.Emergency);
            _rules.Add(eventList[EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED], AlertType.Event);
            _rules.Add(eventList[EventTypes.Essence_EMPTY_BATTERY], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_EXTREME_INACTIVITY], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_Long_Total_Sustained_Activity_Duration], AlertType.Alert);

            _rules.Add(eventList[EventTypes.Essence_LOW_BATTERY], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_LOW_BATTERY_RESET], AlertType.Event);

            _rules.Add(eventList[EventTypes.Essence_MAINS_POWER_FAILURE], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_MAINS_POWER_RESTORED], AlertType.Event);

            _rules.Add(eventList[EventTypes.Essence_NO_PRESENCE], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_PRESENCE], AlertType.Event);

            _rules.Add(eventList[EventTypes.Essence_OUT_OF_HOME_ALERT], AlertType.Event);

            _rules.Add(eventList[EventTypes.Essence_PANEL_OFFLINE], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_PANEL_ONLINE], AlertType.Event);

            _rules.Add(eventList[EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT], AlertType.Alert);
            _rules.Add(eventList[EventTypes.Essence_WANDERING], AlertType.Alert);

 
        }

        public AlertType this[string key]
        {
            get => _rules[key];
        }
    }
}
