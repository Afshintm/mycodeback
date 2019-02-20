using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Enums; 
using Essence.Communication.Models.Utility;
using Essence.Communication.Models.ValueObjects;
using System;
using System.Linq;

namespace Essence.Communication.BusinessServices
{
    public interface IEventCreator
    {
        EventBase Create(IVendorEvent providerEvent, Account hscAccount);
    }
    
    /// <summary>
    /// create the concrete Detail instance of a Event instance against the json payload passed
    /// </summary>
    public class EventCreator : IEventCreator
    {
        private const string Details_Property = "Details";
        private readonly IEventCodeDetailsMapper _eventCodeDetailTypeMapper;
        private readonly IEventAlertRules _eventAlertRule;

        public EventCreator(IEventCodeDetailsMapper eventCodeDetailTypeMapper,
                    IEventAlertRules eventMergencyRules)
        {
            _eventCodeDetailTypeMapper = eventCodeDetailTypeMapper;
            _eventAlertRule = eventMergencyRules;
        }

        public EventBase Create(IVendorEvent eventStructure, Account hscAccount)
        {
            switch(eventStructure.Vendor.Name)
            {
                case EventVendors.ESSENCE:
                    return CreateEssenceEvent(eventStructure, hscAccount);
                default: return null;
            }
        }

       
        /// map essence event common fields into hsc event
        private void MapTo(EssenceEventObjectStructure source, EventBase eventObj)
        {
            eventObj.HSCCode = HSCEventHelper.GetEventCodeFromEssence(source.Event.Code.ToString());
            eventObj.PanelTime = source.PanelTime;
            eventObj.ServiceProvider = source.ServiceProvider;
            eventObj.ServerTime = source.ServerTime;
            eventObj.Location = source.Event.Location;
            eventObj.VendorEventId = source.Id;
        }

        private EventBase CreateEssenceEvent(IVendorEvent eventStructure, Account hscAccount)
        {
            var vendorEvent = eventStructure as EssenceEventObjectStructure;
            if (vendorEvent?.Event == null)
                return null;

            //get details of event against vendor event code
            var detailsType = _eventCodeDetailTypeMapper.GetDetailType(HSCEventHelper.GetEventCodeFromEssence(vendorEvent.Event.Code.ToString()));
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
            eventObj.Account = hscAccount;
            SetDetails(eventObj, detailsObj);
            eventObj.AlertType = _eventAlertRule[HSCEventHelper.GetEventCodeFromEssence(vendorEvent.Event.Code.ToString())];

            MapTo(vendorEvent, eventObj);
            return eventObj;
        }

        private EventBase GetEventWithDetailsType(Type detailsType)
        {
            var eventType = typeof(Event<>).MakeGenericType(detailsType);
            return Activator.CreateInstance(eventType) as EventBase;
        }

        private void SetDetails (EventBase eventObj, IDetails detailsObj)
        {
            //get details property from the event instance
            var propertyInfo = eventObj.GetType().GetProperties().FirstOrDefault(a => a.Name == Details_Property);
            if (propertyInfo == null)
            {
                throw new NotImplementedException("Not support event without details property");
            }

            propertyInfo.SetValue(eventObj, detailsObj);
        }
    }
}
