using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.ValueObjects
{
    public class Period
    {
        public bool Is24Hours { get; set; }
        //HH:mm
        public string PeriodStartTime { get; set; }
        //HH:mm
        public string PeriodEndTime { get; set; }
    }
}
