using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.ValueObjects
{
    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? HorizontalAccuracy { get; set; }
    }
}
