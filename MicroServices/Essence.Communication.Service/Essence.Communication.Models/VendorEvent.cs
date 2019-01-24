using Essence.Communication.Models.Enums;
using System;
using System.Collections.Generic;

namespace Essence.Communication.Models
{ 
    public interface IVendorEvent
    {
        Vendor Vender { get; set; }
    }

    public abstract class VendorEvent: Entity, IVendorEvent
    {
        public Vendor Vender { get; set; }
    }
}
