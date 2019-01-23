using Essence.Communication.Models.ValueObjects;

namespace Essence.Communication.Models
{
    public interface IEvent
    {

    }
    public abstract class EventBase : Entity, IEvent
    {
        public int Account { get; set; }
        public int Code { get; set; }
        public int Severity { get; set; }
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        public string ServerTime { get; set; }
        public bool? IsMobile { get; set; }
        public Location Location { get; set; }

        public string VendorEventId { get; set; }
        public IVendorEvent VendorEvent { get; set; } 
    }

    public class Event<T> : EventBase where T : IDetails
    {
        public T Details {get;set;}
    }   
}
