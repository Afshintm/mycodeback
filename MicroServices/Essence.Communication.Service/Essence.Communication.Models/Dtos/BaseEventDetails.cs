using BuildingBlocks.EventBus.Events;
using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    public abstract class BaseDetails
    {
        public int? DeviceId { get; set; }
        public int? DeviceType { get; set; }
        public string DeviceDescription { get; set; }
    }

    public class ClientInformaion
    {
        public string ApplicationType { get; set; }
        public string MobileDeviceId { get; set; }
    }

    public class PeriodObject
    {
        public bool Is24Hours { get; set; }
        //HH:mm
        public string PeriodStartTime { get; set; }
        //HH:mm
        public string PeriodEndTime { get; set; }
    }  
}
