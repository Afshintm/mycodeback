using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class ActivityRequest
    {
        public string account { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
