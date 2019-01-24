using Essence.Communication.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.ValueObjects
{
    public class EmergencyCategory
    {
        public EmergencyLevels Level { get; set; }
        public string Description { get; set; }
    }
}
