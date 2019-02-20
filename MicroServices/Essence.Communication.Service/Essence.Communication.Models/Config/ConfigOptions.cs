using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essence.Communication.Models.Config
{

    public class ConnectionStrings
    {
        public string ApplicationIdentityConnectionString { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class SupportedEssenceVersion
    {
        public string version1 { get; set; }
        public string version2 { get; set; }
    }

    public class SQSSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string QueueName { get; set; }
    }

    public class ApplicationSettings
    {
        public string ApiEndPoint { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string EssenceBaseUrl { get; set; }
        public SupportedEssenceVersion SupportedEssenceVersion { get; set; }
        public SQSSettings SQSSettings { get; set; }
    }

    public class AuthenticationServer
    {
        public string Issuer { get; set; }
        public string ApiKey { get; set; }
    }

    public class ConfigOptions
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ApplicationSettings ApplicationSettings { get; set; }
        public AuthenticationServer AuthenticationServer { get; set; }
    }
}
