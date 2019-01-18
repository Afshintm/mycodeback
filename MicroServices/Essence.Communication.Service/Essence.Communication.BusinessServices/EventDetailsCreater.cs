using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.BusinessServices.Model;
using Essence.Communication.Models.Dtos;
using Newtonsoft.Json.Linq;
using System;
using HCSLocation = Essence.Communication.BusinessServices.Model.Location;

namespace Essence.Communication.BusinessServices
{
    public interface IEventCreater
    { 
        HSCEvent Create(ProviderEventStructure providerEvent);
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

        public HSCEvent Create(ProviderEventStructure eventStructure)
        {
            if (eventStructure?.Details == null)
            {
                return null;
            }

            var detailType = _eventCodeDetailTypeMapper.GetDetailType(eventStructure.Code);

            var detailsInstance = eventStructure.Details.ToObject(detailType) as BaseDetails;
            return new HSCEvent
            {
                Account = eventStructure.Account,
                Code = eventStructure.Code,
                Severity = eventStructure.Severity,
                Details = detailsInstance,
                DetailsType = detailType,
                PanelTime = eventStructure.PanelTime,
                ServiceProvider = eventStructure.ServiceProvider,
                ServiceType = eventStructure.ServiceType,
                ServerTime = eventStructure.ServerTime,
                IsMobile = eventStructure.IsMobile,
                Location = eventStructure.Location == null ? null :
                            new HCSLocation
                            {
                                Latitude = eventStructure.Location.Latitude,
                                Longitude = eventStructure.Location.Longitude,
                                HorizontalAccuracy = eventStructure.Location.Longitude
                            }
            };
        }
    }
}
