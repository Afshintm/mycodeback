using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.BusinessServices.Model;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Essence.Communication.BusinessServices
{
    public interface IEventCreater
    { 
        IEvent Create(IVendorEvent providerEvent);
    }
    
    /// <summary>
    /// create the concrete Detail instance of a Event instance against the json payload passed
    /// </summary>
    public class EventCreater : IEventCreater
    {
        private readonly IEventCodeDetailsTypeMapper _eventCodeDetailTypeMapper;

        public EventCreater(IEventCodeDetailsTypeMapper eventCodeDetailTypeMapper)
        {
            _eventCodeDetailTypeMapper = eventCodeDetailTypeMapper;
        }

        public IEvent Create(IVendorEvent eventStructure)
        {
            if (eventStructure.vender != Vendor.Essence)
            {
                throw new NotSupportedException($"Vendor {eventStructure.vender.ToString()} is not supported.");
            }

            //TODO vendor event factory, check if supproted
            if (eventStructure.vender == Vendor.Essence)
            {
                var vendorEvent = eventStructure as EssenceEventObjectStructure;
                if (vendorEvent?.Event == null)
                    return null;

                var detailsType = _eventCodeDetailTypeMapper.GetDetailType(vendorEvent.Event.Code);
                
                var detailsInstance = vendorEvent.Event.Details.ToObject(detailsType);
                var eventInstance = GetEventWithDetailsType(detailsType);

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
