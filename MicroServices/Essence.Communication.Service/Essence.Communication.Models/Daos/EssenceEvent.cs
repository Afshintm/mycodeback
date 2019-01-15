using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Essence.Communication.DataBaseServices.Models
{
    public class EssenceEvent
    {
        public int Id { get; set; }
        public long? Account { get; set; }
        //YYY-MM-DDTHH:mm:ss
        public string PanelTime { get; set; }
        //YYY-MM-DDTHH:mm:ss:sssZ
        public string ServerTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        
        public Guid? uid { get; set; }

        public int Code { get; set; }
        public int Severity { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string DetailsJson { get; set; }

        public bool? IsMobile { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? HorizontalAccuracy { get; set; }

    }
}
