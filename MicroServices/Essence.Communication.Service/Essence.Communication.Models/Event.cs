﻿using Essence.Communication.Models.Enums;
using Essence.Communication.Models.ValueObjects;

namespace Essence.Communication.Models
{
    public interface IEvent
    {

    }
    public abstract class EventBase : Entity, IEvent
    {
        private Location location; 
        public EventBase()
        {
            //ef core 2.0 does not support null value object
            location = new Location();
            Status = EventStatus.New;
        } 
        
        //hsc account
        public Account Account { get; set; }
        public AlertType AlertType { get; set; }
        public EventStatus Status { get; set; }
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; } 

        //time the event received or generated in the backend
        public string ServerTime { get; set; }

        //if the event from mobile device
        public bool? IsMobile { get; set; }

        //we do not set vender event as refernce for HSC event
        public string VendorEventId { get; set; } 

        // {VendorType}-{VendorCode}
        public string HSCCode { get; set; }

        public Location Location
        {
            get
            {
                return location;
            }
            set
            {
                //ef core 2.0 does not support null value object
                if (value != default(Location))
                {
                    location = value;
                }
            }
        }
    }

    public class Event<T> : EventBase where T : IDetails
    {
        public T Details {get;set;}
    }   
}
