using Essence.Communication.BusinessServices.Model;
using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices
{

    public interface IModelMapper
    {
        IEvent MapToEvent (IVendorEvent vendorEvent);
        EventViewModel MapToViewModel(IEvent eventObj); 
    }

    //TODO:  replaced by Automapper
    public class ModelMapper : IModelMapper
    {
        public IEvent MapToEvent(IVendorEvent vendorEvent)
        {
            throw new NotImplementedException();
        }

        public EventViewModel MapToViewModel(IEvent eventObj)
        {
            throw new NotImplementedException();
        }
    }
}
