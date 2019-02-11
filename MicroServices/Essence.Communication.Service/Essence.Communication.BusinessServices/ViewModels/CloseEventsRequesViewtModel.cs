using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.BusinessServices.ViewModels
{
    public class CloseEventsRequestViewtModel
    {
        //hsc account
        public int AccountNumber { get; set; }
        public bool OverrideRequesterName { get; set; }
        public int CloseReason { get; set; }  
        public int HandingConclusion { get; set; }
        public string HandlingDescription { get; set; }
        public int SessionData { get; set; }
        public List<Guid> ids { get; set; }
        public List<int> EventTypes { get; set; }
    }
}
