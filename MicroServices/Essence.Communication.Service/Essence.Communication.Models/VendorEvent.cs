using Essence.Communication.Models.Enums;
using System;
using System.Collections.Generic;

namespace Essence.Communication.Models
{ 
    public interface IVendorEvent
    {
        Vendor vender { get; set; }
        List<EventBase> HSCEvents { get; set; }
    }

    public abstract class VendorEvent: Entity, IVendorEvent
    {
        public Vendor vender { get; set; }
        public List<EventBase> HSCEvents { get; set; }
    }
}
