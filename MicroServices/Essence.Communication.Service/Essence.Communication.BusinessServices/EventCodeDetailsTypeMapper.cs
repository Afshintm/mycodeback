using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.BusinessServices.Model;
using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Essence.Communication.BusinessServices
{
    /// <summary>
    /// provide the mapping between event code and the concreate detail type
    /// </summary>
    public interface IEventCodeDetailsTypeMapper
    { 
        Type GetDetailType(int code);
    }
                
    public class EventCodeDetailsTypeMapper : IEventCodeDetailsTypeMapper
    {
        private IDictionary<int, Type> _eventDetaislTypes;
        private readonly IProviderEventTypesManager _eventTypesManager;

        public EventCodeDetailsTypeMapper(IProviderEventTypesManager eventTypesManager)
        {
            _eventTypesManager = eventTypesManager;
            _eventDetaislTypes = new Dictionary<int, Type>();

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.EMERGENCY_PANIC_ALERM], typeof(EmergencyPanicDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.EMERGENCY_PANIC_ALERM_CANCELLED], typeof(EmergencyPanicDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.POSSIBLE_FALL_ALERT], typeof(FallAlertDetails));           

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.PANEL_ONLINE], typeof(PanelStatusDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.PANEL_OFFLINE], typeof(PanelStatusDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.LOW_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.LOW_BATTERY_RESET], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.EMPTY_BATTERY], typeof(BatteryDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.BATTERY_RESTORED], typeof(BatteryDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.MAINS_POWER_FAILURE], typeof(PowerDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.MAINS_POWER_RESTORED], typeof(PowerDetails));

            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.OUT_OF_HOME_ALERT], typeof(StayHomeDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.BACK_AT_HOME_ALERT], typeof(StayHomeDetails));
            
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.UNEXPECTED_ENTRY_OR_EXIT], typeof(UnexpectedEntryExitDetails));
            _eventDetaislTypes.Add(_eventTypesManager[EventTypes.UNUSUAL_ACTIVITY_ALERT], typeof(UnexpectedActivityDetails));
        }

        public Type GetDetailType(int code)
        {
            if (!_eventDetaislTypes.Keys.Contains(code))
            {
                throw new NotSupportedException();
            }

            return _eventDetaislTypes[code];
        }

    }
}
