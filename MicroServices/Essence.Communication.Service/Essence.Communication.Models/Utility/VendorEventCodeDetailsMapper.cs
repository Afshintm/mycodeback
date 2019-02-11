using Essence.Communication.Models.Utility;
using Essence.Communication.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace Essence.Communication.Models.Utility
{
    /// <summary>
    /// provide the mapping between HSC event code and the concreate detail type
    /// </summary>
    public interface IEventCodeDetailsMapper
    { 
        Type GetDetailType(string code);
    }
                
    public class HSCCodeDetailsMapper : IEventCodeDetailsMapper
    {
        private IDictionary<string, Type> _eventDetaislTypes;
        private readonly IEventCodeList _hscCodeList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventTypesManager"></param>
        public HSCCodeDetailsMapper(IEventCodeList hscCodeList)
        {
            _hscCodeList = hscCodeList;
            _eventDetaislTypes = new Dictionary<string, Type>();

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_EMERGENCY_PANIC_ALERM], typeof(EmergencyPanicDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_EMERGENCY_PANIC_ALERM_CANCELLED], typeof(EmergencyPanicDetails));

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_POSSIBLE_FALL_ALERT], typeof(FallAlertDetails));           

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_PANEL_ONLINE], typeof(PanelStatusDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_PANEL_OFFLINE], typeof(PanelStatusDetails));

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_LOW_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_LOW_BATTERY_RESET], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_EMPTY_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_BATTERY_RESTORED], typeof(BatteryDetails));

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_MAINS_POWER_FAILURE], typeof(PowerDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_MAINS_POWER_RESTORED], typeof(PowerDetails));

            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_OUT_OF_HOME_ALERT], typeof(StayHomeDetails));
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_BACK_AT_HOME_ALERT], typeof(StayHomeDetails));
            
            _eventDetaislTypes.Add(_hscCodeList[EventTypes.Essence_UNEXPECTED_ENTRY_OR_EXIT], typeof(UnexpectedEntryExitDetails));
        }

        public Type GetDetailType(string code)
        {
            if (!_eventDetaislTypes.Keys.Contains(code))
            {
                return null;
            }

            return _eventDetaislTypes[code];
        }

    }
}
