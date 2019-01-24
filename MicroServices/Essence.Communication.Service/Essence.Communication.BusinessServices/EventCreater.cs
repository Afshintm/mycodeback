using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums; 
using Essence.Communication.Models.Extensions;
using Essence.Communication.Models.Utility;
using System;

namespace Essence.Communication.BusinessServices
{
    public interface IEventCreater
    {
        EventBase Create(IVendorEvent providerEvent);
    }
    
    /// <summary>
    /// create the concrete Detail instance of a Event instance against the json payload passed
    /// </summary>
    public class EventCreater : IEventCreater
    {
        private readonly IVendorEventCodeDetailsMapper _eventCodeDetailTypeMapper;
        private readonly IEventEmergencyRules _eventMergencyRules;

        public EventCreater(IVendorEventCodeDetailsMapper eventCodeDetailTypeMapper)
        {
            _eventCodeDetailTypeMapper = eventCodeDetailTypeMapper;
        }

        public EventBase Create(IVendorEvent eventStructure)
        {
            if (eventStructure.Vendor != Vendor.Essence)
            {
                throw new NotSupportedException($"Vendor {eventStructure.Vendor.ToString()} is not supported.");
            }

            //TODO vendor event factory, check if supproted
            if (eventStructure.Vendor == Vendor.Essence)
            {
                var vendorEvent = eventStructure as EssenceEventObjectStructure;
                if (vendorEvent?.Event == null)
                    return null;
            
                
                var detailsType = _eventCodeDetailTypeMapper.GetDetailType(vendorEvent.GetVendorEventCode(vendorEvent.Event.Code.ToString()));             
                var detailsInstance = vendorEvent.Event.Details.ToObject(detailsType);
                var eventInstance = GetEventWithDetailsType(detailsType) as EventBase;
                eventInstance.EmergencyCategory = _eventMergencyRules[vendorEvent.GetVendorEventCode(vendorEvent.Event.Code.ToString())];
                eventInstance.VendorEventId = vendorEvent.Id;
                eventInstance.VendorType = vendorEvent.Vendor;
                //TODO mapping vender event to event, check if eventinstance is null

                return eventInstance;
                  
            }
            return null;
        }

        private IEvent GetEventWithDetailsType(Type detailsType)
        {
            var eventType = typeof(Event<>).MakeGenericType(detailsType);
            return Activator.CreateInstance(eventType) as IEvent;
        }
    }
}
