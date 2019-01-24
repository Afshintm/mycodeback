using Essence.Communication.Models.Utility;
using Essence.Communication.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace Essence.Communication.Models.Utility
{
    /// <summary>
    /// provide the mapping between event code and the concreate detail type
    /// </summary>
    public interface IVendorEventCodeDetailsMapper
    { 
        Type GetDetailType(string code);
    }
                
    public class VendorEventCodeDetailsMapper : IVendorEventCodeDetailsMapper
    {
        private IDictionary<string, Type> _eventDetaislTypes;
        private readonly IVendorEventList _eventTypesManager;

        public VendorEventCodeDetailsMapper(IVendorEventList eventTypesManager)
        {
            _eventTypesManager = eventTypesManager;
            _eventDetaislTypes = new Dictionary<string, Type>();

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_EMERGENCY_PANIC_ALERM], typeof(EmergencyPanicDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED], typeof(EmergencyPanicDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_POSSIBLE_FALL_ALERT], typeof(FallAlertDetails));           

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_PANEL_ONLINE], typeof(PanelStatusDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_PANEL_OFFLINE], typeof(PanelStatusDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_LOW_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_LOW_BATTERY_RESET], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_EMPTY_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_BATTERY_RESTORED], typeof(BatteryDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_MAINS_POWER_FAILURE], typeof(PowerDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_MAINS_POWER_RESTORED], typeof(PowerDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_OUT_OF_HOME_ALERT], typeof(StayHomeDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_BACK_AT_HOME_ALERT], typeof(StayHomeDetails));
            
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT], typeof(UnexpectedEntryExitDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.Essence_UNUSUAL_ACTIVITY_ALERT], typeof(UnexpectedActivityDetails));
        }

        public Type GetDetailType(string code)
        {
            if (!_eventDetaislTypes.Keys.Contains(code))
            {
                throw new NotSupportedException();
            }

            return _eventDetaislTypes[code];
        }

    }
}
