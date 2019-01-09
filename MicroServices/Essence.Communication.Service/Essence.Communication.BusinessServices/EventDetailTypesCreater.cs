using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Essence.Communication.BusinessServices
{
    public interface IEventDetailCreater
    { 
        BaseDetails Create(Event eventObj);
    }
                
    public class EventDetailCreater : IEventDetailCreater
    {
        private IDictionary<int, Type> _eventDetails;

        public EventDetailCreater()
        {
            _eventDetails = new Dictionary<int, Type>();
            _eventDetails.Add(156, typeof(EmergencyPanicAlarmDetails));
            _eventDetails.Add(2105, typeof(NoPresenceDetails));
            _eventDetails.Add(113, typeof(HotTemperatureAlarmDetails));
            _eventDetails.Add(206, typeof(LowBatteryRestoreDetails));
        }

        public BaseDetails Create(Event eventObj)
        {
            if (eventObj?.Details == null)
            {
                return null;
            }

            var detailType = MapType(eventObj.Code);
            return eventObj.Details.ToObject(detailType) as BaseDetails;
        }

        private Type MapType(int code)
        {
            if (!_eventDetails.Keys.Contains(code))
            {
                throw new NotSupportedException();
            }

            return _eventDetails[code];

        }

    }
}
