using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Services.Utils
{
    
   
    public interface IHttpClientManager
    {
        Task<T> GetAsync<T>(string path, string parameters = null) where T : class;
        //Task<T> PostAsync<T,K>(string path, K body,string token = null) where T: class where K : class;
        Task<T> PostAsync<T>(string path, object body, string token = null) where T : class;
        string ParamBuilder(string controller, string action = null, Dictionary<string, string> parameters = null, bool keyValuPairFlag = false);
    }

    public class HttpClientManager : IHttpClientManager
    {
        private HttpClient client;
        public HttpClientManager()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string path, string parameters = null) where T : class
        {
            T obj = null;
            var p = parameters?? string.Empty;

            HttpResponseMessage response = await client.GetAsync(path + (parameters ?? string.Empty));
            if (response.IsSuccessStatusCode)
            {
                obj = await response.Content.ReadAsAsync<T>();
            }
            return obj;
        }

        //public async Task<T> PostAsync<T, K>(string path, K body, string token = null) where T : class where K : class
        //{
        //    T result = null;
        //    var stringContent = new JsonContent<K>(body);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
        //    }
        //    HttpResponseMessage response = await client.PostAsync(path, stringContent);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsAsync<T>() ;
        //    }
        //    return result;
        //}
        public async Task<T> PostAsync<T>(string path, object body, string token = null) where T : class
        {
            T result = null;
            var stringContent = new JsonContent(body);
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            }
            HttpResponseMessage response = await client.PostAsync(path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;

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


    }

    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }

    public class JsonContent<T> : StringContent
    {
        public JsonContent(T obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") { }
    }
}
