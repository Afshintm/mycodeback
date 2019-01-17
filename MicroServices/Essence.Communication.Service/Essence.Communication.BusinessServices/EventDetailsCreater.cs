using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Essence.Communication.BusinessServices
{
    public interface IEventDetailsCreater
    { 
        BaseDetails Create(Event eventObj);
    }
    
    /// <summary>
    /// create the concrete Detail instance of a Event instance against the json payload passed
    /// </summary>
    public class EventDetailsCreater : IEventDetailsCreater
    {
        private readonly IEventCodeDetailsTypeMapper _eventCodeDetailTypeMapper;

        public EventDetailsCreater(IEventCodeDetailsTypeMapper eventCodeDetailTypeMapper)
        {
            _eventCodeDetailTypeMapper = eventCodeDetailTypeMapper;
        }

        public BaseDetails Create(Event eventObj)
        {
            if (eventObj?.Details == null)
            {
                return null;
            }

            var detailType = _eventCodeDetailTypeMapper.GetDetailType(eventObj.Code);
            return eventObj.Details.ToObject(detailType) as BaseDetails;
        }
    }
}
