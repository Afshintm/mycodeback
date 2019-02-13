using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utils
{
    public interface IHttpClientManagerNew
    {
        Task<T> GetAsync<T>(string path, string parameters = null) where T : class;
        Task<T> PostAsync<T>(string path, object body) where T : class;
        string ParamBuilder(string controller, string action = null, Dictionary<string, string> parameters = null, bool keyValuPairFlag = false);
        void ConfigurateHttpClient(string baseUrl, IDictionary<string, string> headers);

    }

    /// <summary>
    /// compared with old HttpClientManager
    /// 1> Return unsuccessful response content;
    /// 2> Be able to add request headers
    /// 3> Encapsulate process of sending request and handle response in sperated function "InvokeAsync"
    /// </summary>
    public class HttpClientManagerNew : IHttpClientManagerNew
    {
        private HttpClient _client;
        public HttpClientManagerNew()
        {
            _client = new HttpClient();
        }  

        public async Task<T> GetAsync<T>(string path, string parameters = null) where T : class
        {
            var p = parameters ?? string.Empty;

            return await InvokeAsync<T>(
                client => client.GetAsync(path + (parameters ?? string.Empty)),
                response => response.Content.ReadAsAsync<T>());
        }

        public async Task<T> PostAsync<T>(string path, object body) where T : class
        {
            var stringContent = new JsonContent(body);

            return await InvokeAsync<T>(
                client => client.PostAsync(path, stringContent),
                response => response.Content.ReadAsAsync<T>());
        }

        public string ParamBuilder(string controller, string action = null, Dictionary<string, string> parameters = null, bool keyValuPairFlag = false)
        {
            var apiParameters = controller + (!string.IsNullOrEmpty(action) ? "/" + action : "");
            int i = 0;
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> keyValPair in parameters)
                {
                    if (keyValuPairFlag == false)
                    {
                        apiParameters = apiParameters + "/" + keyValPair.Value;
                    }
                    else
                    {
                        apiParameters = apiParameters + (i == 0 ? "" : "&") + keyValPair.Key + "=" + keyValPair.Value;
                        i++;
                    }
                }
            }
            return apiParameters;
        }

        private async Task<T> InvokeAsync<T>(
                Func<HttpClient, Task<HttpResponseMessage>> operation,
                Func<HttpResponseMessage, Task<T>> callBackAction = null)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            HttpResponseMessage response = await operation(_client);

            if (!response.IsSuccessStatusCode)
            {
                var exception = new HttpClientManagerException ($"Resource server returned an error. StatusCode : {response.StatusCode}");
                exception.StatusCode = response.StatusCode;
                exception.ResponseConetent = response.Content;
                throw exception;
            }
            if (callBackAction != null)
            {
                return await callBackAction(response);
            }
            else
            {
                return default(T);
            }
        }

        private void ResetConfiguration()
        {
            _client.DefaultRequestHeaders.Clear();
        }

        public void ConfigurateHttpClient(string baseUrl, IDictionary<string, string> headers)
        {
            //clear headers
            ResetConfiguration();

            // do this first
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new Exception("BaseAddress is required!");
            }

            if (headers != null)
            {
                if (headers.Keys.Contains("Authorization"))
                {
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Token {headers["Authorization"]}");
                }

                if (headers.Keys.Contains("Accept"))
                {
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headers["Accept"]));
                }

                if (headers.Keys.Contains("Host"))
                {
                    _client.DefaultRequestHeaders.Host = headers["Host"];
                }
            } 
            _client.BaseAddress = new Uri(baseUrl);
            _client.Timeout = new TimeSpan(0, 0, 0, 10);
        }

    }

}
