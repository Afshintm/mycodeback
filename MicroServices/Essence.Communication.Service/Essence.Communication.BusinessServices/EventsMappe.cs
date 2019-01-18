using Essence.Communication.BusinessServices.Model;
using Essence.Communication.DataBaseServices.Daos;
using Essence.Communication.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices
{

    public interface IModelMapper
    {
        HSCEventDAO GetDAO (HSCEvent eventObj);
        EssenceEventDAO GetDAO(EssenceEventObjectStructure eventObj);
        ProviderEventStructure GetEventStructure(EssenceEventObjectStructure eventObj);

        HSCEvent GetHSCEvent(HSCEventDAO eventDAO);
    }

    //TODO:  replaced by Automapper
    public class ModelMapper: IModelMapper
    {
        private readonly IEventCodeDetailsTypeMapper _eventCodeDetailTypeMapper;

        public ModelMapper(IEventCodeDetailsTypeMapper eventCodeDetailTypeMapper)
        {

        }
 

        public HSCEventDAO GetDAO(HSCEvent eventObj)
        {
            throw new NotImplementedException();
        }

        public EssenceEventDAO GetDAO(EssenceEventObjectStructure eventObj)
        {
            if (eventObj.Event == null)
                return null;

            return new EssenceEventDAO
            {
                EventId = eventObj.Guid,
                Account = eventObj.Account,
                Code = eventObj.Event.Code,
                Severity = eventObj.Event.Severity,
                ServerTime = eventObj.ServerTime,
                PanelTime = eventObj.PanelTime,
                ServiceProvider = eventObj.ServiceProvider,
                ServiceType = eventObj.ServiceType,
                DetailsJson = eventObj.Event.Details?.ToString(),
                IsMobile = eventObj.Event.IsMobile,
                Latitude = eventObj.Event.Location?.Latitude,
                Longitude = eventObj.Event.Location?.Longitude,
                HorizontalAccuracy = eventObj.Event.Location.HorizontalAccuracy
            };
        }

        public HSCEvent GetDTO(HSCEventDAO eventObj)
        {
            throw new NotImplementedException();
        }

        public ProviderEventStructure GetEventStructure(EssenceEventObjectStructure essenceEvent)
        {
            if (essenceEvent.Event == null)
                return null;

            return new ProviderEventStructure
            {
                Account = essenceEvent.Account,
                Code = essenceEvent.Event.Code,
                Severity = essenceEvent.Event.Severity,
                Details = essenceEvent.Event.Details,
                PanelTime = essenceEvent.PanelTime,
                ServiceProvider = essenceEvent.ServiceProvider,
                ServiceType = essenceEvent.ServiceType,
                ServerTime = essenceEvent.ServerTime,
                Location = essenceEvent.Event.Location
            };
        }


        //TODO: need to replaced by AUTOMAPPEr
        public HSCEvent GetHSCEvent(HSCEventDAO eventDAO)
        {
            if (eventDAO == null)
            {
                return null;
            }

            var detailType = _eventCodeDetailTypeMapper.GetDetailType(eventDAO.Code);

            //TODO need to replaced by automapper
            var daojson = JsonConvert.SerializeObject(eventDAO);
            var eventObj = JsonConvert.DeserializeObject<HSCEvent>(daojson);
            var details = JsonConvert.DeserializeObject(daojson, detailType) as BaseDetails;
            eventObj.Details = details;
            eventObj.DetailsType = detailType;
            return eventObj;
        }
    }
}
