using BuildingBlocks.EventBus.Events;

namespace Essence.Communication.Models.Dtos
{
    public class EventObjectStructure : IntegrationEvent
    {
        public int Account { get; set; }
        public Event Event { get; set; }
        //YYY-MM-DDTHH:mm:ss
        public string PanelTime { get; set; }
        //YYY-MM-DDTHH:mm:ss:sssZ
        public string ServerTime { get; set; }

        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        //Guid
        public string Id { get; set; }
        
    }

    public class Event
    {
        public int Code { get; set; }
        public int Severity { get; set; }
        public BaseDetails Details { get; set; }

        public bool? IsMobile { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public long HorizontalAccuracy { get; set; }
    }
}
