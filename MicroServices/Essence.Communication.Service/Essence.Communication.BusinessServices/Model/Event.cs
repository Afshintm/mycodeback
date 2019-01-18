﻿
using Essence.Communication.DataBaseServices.Daos;
using System; 

namespace Essence.Communication.BusinessServices.Model
{
    //Event Inheritance for HomeStay Care
    public class  HSCEvent  
    {
        public Guid guid { get; set; }
        public Guid EventId { get; set; }
        public int Account { get; set; }
        public int Code { get; set; }
        public int Severity { get; set; }
        public BaseDetails Details { get; set; }
        public Type DetailsType { get; set; }
        public string PanelTime { get; set; }
        public int? ServiceProvider { get; set; }
        public int? ServiceType { get; set; }
        public string ServerTime { get; set; }
        public bool? IsMobile { get; set; }
        public Location Location { get; set; }   
        
        public static HSCEventDAO MapToDAO(HSCEvent eventObj)
        {
            //TODO: automapper
            return new HSCEventDAO();
        }
    }

    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int HorizontalAccuracy { get; set; }
    }

}
