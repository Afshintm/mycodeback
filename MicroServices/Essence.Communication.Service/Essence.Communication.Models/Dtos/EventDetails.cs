using BuildingBlocks.EventBus.Events;
using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    public class BaseDetails
    {
        public int DeviceId { get; set; }
        public int DeviceType { get; set; }
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
    public class Details
    {
        public int DeviceId { get; set; }
        public int DeviceType { get; set; }
        public string DeviceDescription { get; set; }

        public int? ConfidenceLevel { get; set; } //todo enum
        public int? Trigger { get; set; } //todo enum
        public int RadioLevel { get; set; }//todo enum //sometimes mandatory   fire cancelled

        //hot temperature
        public int MaxinumThreshold { get; set; }
        public int ActualTemperature { get; set; }
        //cold
        public int MinimumThreshold { get; set; }

        //Mains Power failure
        public string PowerFailureDuration { get; set; }

        public string PowerRestoreDuration { get; set; }

        //battery
        public int BatteryLevel { get; set; }

        //messages
        public int TransmissionType { get; set; } //todo enum
        public string TransmissionFaultDuration { get; set; }

        //software release
        public int HardwareType { get; set; }
        public int Softwaretype { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int SubVersion { get; set; }

        //timezone update
        public string PreviousTimeZone { get; set; }
        public string NewTimeZone { get; set; }

        //control panel file (cp file)
        public int FileType { get; set; } //todo enum
        public int Result { get; set; }//todo enum

        //device reset
        public int ReasonCode { get; set; } // todo enum

        //paried with mobile phone
        public ClientInformaion ClientInformaion { get; set; }

        //offline
        public string LastContactTime { get; set; } //only

        //email SMS notification failed
        public string Destination { get; set; } //only

        //photo received
        List<string> Links { get; set; }

        //possible failed
        public string DurationInRoom { get; set; }

        //unusual activity
        public int Grade { get; set; }

        //door
        public int ActivityType { get; set; } //todo enum
        public string DoorOpenDuration { get; set; }
        public string DoorOpenTime { get; set; }

        //out door
        public string ExitTime { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }
        public string MaximumOutOfHomeDuration { get; set; }

        //back homne
        public string EntryTime { get; set; }

        //no active
        public PeriodObject Period { get; set; }

        //Low number of detections
        public int ExpectedDetections { get; set; }
        public int ActualDetections { get; set; }

        //low nbumber of peiods of sustained activity
        public int ExpectedVisits { get; set; }
        public int ActualVisits { get; set; }

        //short total sustained activity duration
        public string ExpectedDuration { get; set; }
        public string ActualDuration { get; set; }

        //Extreme inactivity
        public string Since { get; set; }
    }
    }
