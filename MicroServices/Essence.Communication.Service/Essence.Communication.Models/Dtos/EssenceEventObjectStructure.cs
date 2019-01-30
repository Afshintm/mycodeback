using BuildingBlocks.EventBus.Events;
using Essence.Communication.Models.Enums;
using Essence.Communication.Models.ValueObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    /// <summary>
    /// Type to map event payload frem Essence
    /// </summary>
    public class EssenceEventObjectStructure : VendorEvent
    {
        public EssenceEventObjectStructure()
        {
            this.Vendor = Vendor.Essence;
        }
        public int Account { get; set; }
        public EssenceEventObject Event { get; set; }
        //YYY-MM-DDTHH:mm:ss
        public string PanelTime { get; set; }
        //YYY-MM-DDTHH:mm:ss:sssZ
        public string ServerTime { get; set; }

        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }

        // Essence Original Event Id
        public List<Guid> EventId { get; set; }
    }

    public class EssenceEventObject
    {
        private Location location;
        public EssenceEventObject()
        {
            //ef core 2.0 not support null value object
            location = new Location();
        }
        public int Code { get; set; }
        public int Severity { get; set; }
        public JObject Details { get; set; }
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
    }
}
