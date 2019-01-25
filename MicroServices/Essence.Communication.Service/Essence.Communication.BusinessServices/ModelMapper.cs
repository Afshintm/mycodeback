using Essence.Communication.BusinessServices.ViewModel;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices
{

    public interface IModelMapper
    { 
        EventViewModel MapToViewModel(IEvent eventObj); 
    }
    
    public class ModelMapper : IModelMapper
    { 
        public EventViewModel MapToViewModel(IEvent eventObj)
        {
            if (eventObj == null)
                return null;

            var source = eventObj as EventBase;
            var eventType = eventObj.GetType();

            return CreateViewModel(eventType, source);
        }

        private EventViewModel CreateViewModel(Type eventType, EventBase source)
        {
            if (eventType == typeof(Event<BatteryDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<BatteryDetails>)) as Event<BatteryDetails>;
                var destination = new BatteryEventViewModel() { Details = new BatteryDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                MapBaseDeviceDetails(destination.Details, hscEvent.Details);
                destination.Details.BatteryLevel = hscEvent.Details.BatteryLevel;
                return destination;
            }

            if (eventType == typeof(Event<UnexpectedEntryExitDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<UnexpectedEntryExitDetails>)) as Event<UnexpectedEntryExitDetails>;
                var destination = new UnexpectedEntryExitEventViewModel() { Details = new UnexpectedEntryExitDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                MapBaseDeviceDetails(destination.Details, hscEvent.Details);
                destination.Details.Is24Hours = hscEvent.Details.Period.Is24Hours;
                destination.Details.PeriodStartTime = hscEvent.Details.Period.PeriodStartTime;
                destination.Details.PeriodEndTime = hscEvent.Details.Period.PeriodEndTime;
                return destination;
            }

            if (eventType == typeof(Event<StayHomeDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<StayHomeDetails>)) as Event<StayHomeDetails>;
                var destination = new StayHomeEventViewModel() { Details = new StayHomeDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                destination.Details.ExitTime = hscEvent.Details.ExitTime;
                destination.Details.PeriodStartTime = hscEvent.Details.PeriodStartTime;
                destination.Details.PeriodEndTime = hscEvent.Details.PeriodEndTime;
                destination.Details.MaximumOutOfHomeDuration = hscEvent.Details.MaximumOutOfHomeDuration;
                destination.Details.EntryTime = hscEvent.Details.EntryTime;
                return destination;
            }

            if (eventType == typeof(Event<PowerDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<PowerDetails>)) as Event<PowerDetails>;
                var destination = new PowerEventViewModel() { Details = new PowerDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                MapBaseDeviceDetails(destination.Details, hscEvent.Details);
                destination.Details.PowerFailureDuration = hscEvent.Details.PowerFailureDuration;
                destination.Details.PowerRestoredDuration = hscEvent.Details.PowerRestoredDuration;
                return destination;
            }

            if (eventType == typeof(Event<PanelStatusDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<PanelStatusDetails>)) as Event<PanelStatusDetails>;
                var destination = new PanelStatusEventViewModel() { Details = new PanelStatusDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent); 
                destination.Details.LastContactTime = hscEvent.Details.LastContactTime;
                return destination;
            }

            if (eventType == typeof(Event<FallAlertDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<FallAlertDetails>)) as Event<FallAlertDetails>;
                var destination = new FallAlertEventViewModel() { Details = new FallAlertDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                MapBaseDeviceDetails(destination.Details, hscEvent.Details);
                destination.Details.Activitytype = hscEvent.Details.Activitytype;
                destination.Details.DurationInRoom = hscEvent.Details.DurationInRoom;
                return destination;
            }

            if (eventType == typeof(Event<EmergencyPanicDetails>))
            {
                var hscEvent = Convert.ChangeType(source, typeof(Event<EmergencyPanicDetails>)) as Event<EmergencyPanicDetails>;
                var destination = new EmergencyPanicEventViewModel() { Details = new EmergencyPanicDetailsViewModel() };
                MapBaseViewModel(destination, hscEvent);
                MapBaseDeviceDetails(destination.Details, hscEvent.Details);
                return destination;
            }

            return null;
        }

        private void MapBaseViewModel(EventViewModel destination, EventBase source)
        {
            destination.HSCCode = source.HSCCode;

            //TODO: change utc time to local time
            destination.CreateTime = source.CreateDate.ToString();
            destination.Level = source.EmergencyCategory == null ? 0 : (int)source.EmergencyCategory.Level;
            destination.EmergencyDescription = source.EmergencyCategory?.Description;
        }

        private void MapBaseDeviceDetails(DeviceEventDetailsViewModel destination, DeviceEventDetails source)
        {
            destination.DeviceId = source.DeviceId;
            destination.DeviceType = source.DeviceType;
            destination.DeviceDescription = source.DeviceDescription;
        }
    }

   

    
}
