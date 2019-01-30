using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Essence.Communication.BusinessServices
{
    public interface IRequestValidation
    {
        HttpResponseMessage CheckHeaders(IHeaderDictionary headers);
    }

    public class EssenceRequestValidation : IRequestValidation
    {
        private readonly IAppSettingsConfigService _appSetting;
        private const string ContentType = "Content-Type";
        private const string Authentication = "Authorization";
        private const string jsonCententType = "application/json";

        public EssenceRequestValidation(IAppSettingsConfigService appSetting)
        {
            _appSetting = appSetting;
        }

        public HttpResponseMessage CheckHeaders(IHeaderDictionary headers)
        {
            if (headers.TryGetValue(ContentType, out StringValues values))
            {
                var result = CheckContentType(values.First().ToString());
                if (!result.IsSuccessStatusCode)
                    return result;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (headers.TryGetValue(Authentication, out StringValues authHeader))
            {
                var result = CheckAuthHeader(authHeader.First().ToString());
                if (!result.IsSuccessStatusCode)
                    return result;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private HttpResponseMessage CheckContentType(string contentTypeValue)
        {
            if (string.IsNullOrEmpty(contentTypeValue))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //need 2 parameters
            var contentyTypes = contentTypeValue.Split(';');
            if (contentyTypes.Length != 2)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            //not support json
            if (!contentyTypes[0].Equals(jsonCententType, StringComparison.CurrentCultureIgnoreCase))
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            if (!contentyTypes[0].Equals(jsonCententType, StringComparison.CurrentCultureIgnoreCase))
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            var profiles = contentyTypes[1].Trim();
            var start = profiles.IndexOf('"') + 1;
            var length = profiles.LastIndexOf('"') - start;

            var version = profiles.Substring(start, length);

            if (_appSetting.SupportEssenceVersion.Any(x => x.Trim().Equals(version, StringComparison.CurrentCultureIgnoreCase)) == false)
            {

                var response = new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
                var unSupported = $"Unsupported version: {version.Trim()}";
                var supported = $"Supported versions: {string.Join(",", _appSetting.SupportEssenceVersion.Select(x => x.Trim()).ToArray())}";
                response.Content = new StringContent(unSupported + "\r\n" + supported);
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private HttpResponseMessage CheckAuthHeader(string authHeader)
        {
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();

                //decoding
                var encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                var userPasswordPair = usernamePassword.Split(':');

                if (userPasswordPair.Length != 2)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                var userName = userPasswordPair[0].Trim();
                var passWord = userPasswordPair[1].Trim();

                //TODO: validate username/password
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                //header is not in valid format
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }

}
