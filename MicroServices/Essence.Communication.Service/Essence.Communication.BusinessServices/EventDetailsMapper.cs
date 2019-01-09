using BuildingBlocks.EventBus.Interfaces;
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

        public EventCodeDetailsTypeMapper()
        {
            _eventDetaislTypes = new Dictionary<int, Type>();
            _eventDetaislTypes.Add(156, typeof(EmergencyPanicAlarmDetails));
            _eventDetaislTypes.Add(2105, typeof(NoPresenceDetails));
            _eventDetaislTypes.Add(113, typeof(HotTemperatureAlarmDetails));
            _eventDetaislTypes.Add(206, typeof(LowBatteryRestoreDetails));
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
