using System;

namespace MyIdentity.Configs
{
    public class GlobalConfiguration
    {
        public const string issuer = "http://identitymanagementapi-1966185121.ap-southeast-2.elb.amazonaws.com";
        public const string jwks_uri = "https://localhost:44343/.well-known/openid-configuration/jwks";
        public const string authorization_endpoint = "https://localhost:44343/connect/authorize";
        public const string token_endpoint = "https://localhost:44343/connect/token";
        public const string userinfo_endpoint = "https://localhost:44343/connect/userinfo";
        public const string end_session_endpoint = "https://localhost:44343/connect/endsession";
        public const string check_session_iframe = "https://localhost:44343/connect/checksession";
        public const string revocation_endpoint = "https://localhost:44343/connect/revocation";
        public const string introspection_endpoint = "https://localhost:44343/connect/introspect";
        public const string device_authorization_endpoint = "https://localhost:44343/connect/deviceauthorization";
    }
}
