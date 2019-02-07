using Essence.Communication.BusinessServices.ViewModel;
using Essence.Communication.Models.ValueObjects;
using System; 

namespace Essence.Communication.BusinessServices.ViewModel
{
    public abstract class  EventViewModel  
    {
        public string HSCCode { get; set; }
        public string CreateTime { get; set; }  
        public string AlertType { get; set; } 
    }

    public class UnexpectedActivityEventViewModel : EventViewModel
    {
       public UnexpectedActivityDetailsViewModel Details { get; set; }
    }

    public class UnexpectedEntryExitEventViewModel : EventViewModel
    {
        public UnexpectedEntryExitDetailsViewModel Details { get; set; }
    }

    public class StayHomeEventViewModel : EventViewModel
    {
        public StayHomeDetailsViewModel Details { get; set; }
    }
    public class PowerEventViewModel : EventViewModel
    {
        public PowerDetailsViewModel Details { get; set; }
    }
    public class BatteryEventViewModel : EventViewModel
    {
        public BatteryDetailsViewModel Details { get; set; }
    }
    public class PanelStatusEventViewModel : EventViewModel
    {
        public PanelStatusDetailsViewModel Details { get; set; }
    }
    public class FallAlertEventViewModel : EventViewModel
    {
        public FallAlertDetailsViewModel Details { get; set; }
    }

    public class EmergencyPanicEventViewModel : EventViewModel
    {
        public EmergencyPanicDetailsViewModel Details { get; set; }
    }
}
