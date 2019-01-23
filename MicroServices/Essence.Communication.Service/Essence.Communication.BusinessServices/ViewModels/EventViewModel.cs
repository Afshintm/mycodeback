using Essence.Communication.Models.ValueObjects;
using System; 

namespace Essence.Communication.BusinessServices.Model
{
    //TODO: view model content is similar as model at the stage
    public class  EventViewModel  
    {
        public string Id { get; set; } 
        public int Account { get; set; }
        public int Code { get; set; }
        public int Severity { get; set; } 
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        public string ServerTime { get; set; }
        public bool? IsMobile { get; set; }
        public Location Location { get; set; }   
        
    }

    

     

}
