using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Essence.Communication.DataBaseServices.Daos
{ 
    public class HSCEventDAO
    {
        public int Id { get; set; }
       
        public Guid EventId { get; set; } 

        //nullable fk
        public Guid? OriginalEventId { get; set; }
        public EssenceEventDAO OriginalEvent { get; set; }

        public long Account { get; set; } 
        public string PanelTime { get; set; } 
        public string ServerTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; } 
      
        public int Code { get; set; }
        public int? Severity { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int? HorizontalAccuracy { get; set; }
        public bool? IsMobile { get; set; }

        public string DeviceId { get; set; }
        public int? DeviceType { get; set; }
        public string DeviceDescription { get; set; }

        public string PowerFailureDuration { get; set; }
        public string PowerRestoredDuration { get; set; }
        public int? BatteryLevel { get; set; }
        public string LastContactTime { get; set; }
        public int? ActivityType { get; set; }
        public string DurationInRoom { get; set; }
        public int? Grade { get; set; }

        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }
        public string  EntryTime { get; set; }


    }
}
