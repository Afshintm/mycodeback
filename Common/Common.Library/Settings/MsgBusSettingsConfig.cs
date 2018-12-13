using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library.Settings
{
    public class MsgBusSettingsConfig
    {
        public string HostConnectionString { get; set; }
        public string BrokerName { get; set; }
        public string PersistentConnectionString { get; set; }
    }
}
