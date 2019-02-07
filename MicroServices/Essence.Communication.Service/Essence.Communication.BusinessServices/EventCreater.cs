using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums; 
using Essence.Communication.Models.Extensions;
using Essence.Communication.Models.Utility;
using Essence.Communication.Models.ValueObjects;
using System;
using System.Linq;

namespace Essence.Communication.BusinessServices
{
    public interface IEventCreater
    {
        EventBase Create(IVendorEvent providerEvent, string hscAccountId);
    }
    
    /// <summary>
    /// create the concrete Detail instance of a Event instance against the json payload passed
    /// </summary>
    public class EventCreater : IEventCreater
    {
        private const string Details_Property = "Details";
        private readonly IVendorEventCodeDetailsMapper _eventCodeDetailTypeMapper;
        private readonly IEventAlertRules _eventAlertRule;

        public EventCreater(IVendorEventCodeDetailsMapper eventCodeDetailTypeMapper,
                    IEventAlertRules eventMergencyRules)
        {
            _eventCodeDetailTypeMapper = eventCodeDetailTypeMapper;
            _eventAlertRule = eventMergencyRules;
        }

        public EventBase Create(IVendorEvent eventStructure, string hscAccountId)
        {
            if (eventStructure.Vendor != Vendor.Essence)
            {
                throw new NotSupportedException($"Vendor {eventStructure.Vendor.ToString()} is not supported.");
            }
            
            if (eventStructure.Vendor == Vendor.Essence)
            {
                var vendorEvent = eventStructure as EssenceEventObjectStructure;
                if (vendorEvent?.Event == null)
                    return null;          
                
                //get details of event against vendor event code
                var detailsType = _eventCodeDetailTypeMapper.GetDetailType(vendorEvent.GetVendorEventCode(vendorEvent.Event.Code.ToString()));     
                if (detailsType == null)
                {
                    throw new NotImplementedException();
                }

                var deatils = vendorEvent.Event.Details;
                var detailsObj = (deatils == null ? Activator.CreateInstance(detailsType) : deatils.ToObject(detailsType)) as IDetails;

                //create specific hsc event object based on the details type
                var eventObj = GetEventWithDetailsType(detailsType);
                if (eventObj == null)
                    return null;
                //set  properties
                eventObj.AccountId = hscAccountId;
                SetDetails(eventObj, detailsObj);
                eventObj.AlertType = _eventAlertRule[vendorEvent.GetVendorEventCode(vendorEvent.Event.Code.ToString())];

                MapTo(vendorEvent, eventObj);
                return eventObj;             
            }

            return null;
        }

        /// <summary>
        /// map commen essence event into hsc event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventObj"></param>
        private void MapTo(EssenceEventObjectStructure source, EventBase eventObj)
        {
            eventObj.HSCCode = source.GetVendorEventCode(source.Event.Code.ToString());
            eventObj.PanelTime = source.PanelTime;
            eventObj.ServiceProvider = source.ServiceProvider;
            eventObj.ServerTime = source.ServerTime;
            eventObj.Location = source.Event.Location;
            eventObj.VendorEventId = source.Id;
            eventObj.VendorType = source.Vendor;
        }

        private EventBase GetEventWithDetailsType(Type detailsType)
        {
            var eventType = typeof(Event<>).MakeGenericType(detailsType);
            return Activator.CreateInstance(eventType) as EventBase;
        }

        private void SetDetails (EventBase eventObj, IDetails detailsObj)
        {
            var propertyInfo = eventObj.GetType().GetProperties().FirstOrDefault(a => a.Name == Details_Property);
            if (propertyInfo == null)
            {
                throw new NotImplementedException("Not support event without details property");
            }

            propertyInfo.SetValue(eventObj, detailsObj);
        }
    }
}
