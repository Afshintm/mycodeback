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

        public static EssenceEventDAO CreateEntity(EssenceEventObjectStructure essenceEvent)
        {
            //todo: automapper
            return new EssenceEventDAO();
        }

        public static ProviderEventStructure CreateStructure(EssenceEventObjectStructure essenceEvent)
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
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public long HorizontalAccuracy { get; set; }
    }
}
