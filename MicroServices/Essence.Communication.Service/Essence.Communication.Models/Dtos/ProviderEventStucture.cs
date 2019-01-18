using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class ProviderEventStructure
    {
        public int Account { get; set; }
        public int Code { get; set; }
        public int Severity { get; set; }
        public JObject Details { get; set; }
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        public string ServerTime { get; set; }
        public bool? IsMobile { get; set; }
        public Location Location { get; set; }
    }
}
