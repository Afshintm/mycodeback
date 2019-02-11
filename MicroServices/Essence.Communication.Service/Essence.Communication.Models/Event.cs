using Essence.Communication.Models.Enums;
using Essence.Communication.Models.ValueObjects;

namespace Essence.Communication.Models
{
    public interface IEvent
    {

    }
    public abstract class EventBase : Entity, IEvent
    {
        private Location location;
        private EmergencyCategory emergencyCategory;
        public EventBase()
        {
            //ef core 2.0 not support null value object
            location = new Location();
            emergencyCategory = new EmergencyCategory();
        } 

        public int Account { get; set; }
        public int Severity { get; set; }
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        public string ServerTime { get; set; }
        public bool? IsMobile { get; set; }
        public Location Location
        {
            get
            {
                return location;
            }
            set
            {
                //ef core 2.0 not support null value object
                if (value != default(Location))
                {
                    location = value;
                }
            }
        }

        //we do not set vender event as refernce for HSC event
        public Vendor VendorType { get; set; }
        public string VendorEventId { get; set; }

        //EmergencyCategory
        public EmergencyCategory EmergencyCategory
        {
            get
            {
                return emergencyCategory;
            }
            set
            {
                //ef core 2.0 not support null value object
                if (value != default(EmergencyCategory))
                {
                    emergencyCategory = value;
                }
            }
        }

        //TODO: need to map Hsc userID from vendor events in next MVP
        public string UserID { get; set; }

        //TODO: Map vendor's code into hsc code
        public string HSCCode { get; set; }
    }

    public class Event<T> : EventBase where T : IDetails
    {
        public T Details {get;set;}
    }   
}
