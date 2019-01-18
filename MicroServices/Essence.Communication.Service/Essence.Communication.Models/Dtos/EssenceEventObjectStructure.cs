using BuildingBlocks.EventBus.Events;
using Essence.Communication.DataBaseServices.Daos;
using Newtonsoft.Json.Linq;

namespace Essence.Communication.Models.Dtos
{
    /// <summary>
    /// Type to map event payload frem Essence
    /// </summary>
    public class EssenceEventObjectStructure : IntegrationEvent
    {
        public int Account { get; set; }
        public EssenceEventObject Event { get; set; }
        //YYY-MM-DDTHH:mm:ss
        public string PanelTime { get; set; }
        //YYY-MM-DDTHH:mm:ss:sssZ
        public string ServerTime { get; set; }

        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        //Guid
        public string Id { get; set; }
    }

    public class EssenceEventObject
    {
        public int Code { get; set; }
        public int Severity { get; set; }
        public JObject Details { get; set; }

        public bool? IsMobile { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int HorizontalAccuracy { get; set; }
    }
}
