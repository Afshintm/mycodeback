using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Services.Utils
{
    public interface IBaseBusinessService<T>
    {
        IEnumerable<T> GetAll();
        string ApiEndPoint { get; set; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> PostAsync(object data, string token = null);
    }
    public abstract class BaseBusinessServices<T> : IBaseBusinessService<T> where T : class
    {

        private IHttpClientManager _httpClientManager;
        private readonly IConfiguration _configuration;
        public string ApiEndPoint { get; set; }

        public void SetupApiAddress()
        {
            SetApiEndpointAddress();
            if (string.IsNullOrEmpty(ApiEndPoint))
            {
                throw new ApplicationException($"No endpoint is provided.");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            SetupApiAddress();
            var result = await _httpClientManager.GetAsync<IEnumerable<T>>(ApiEndPoint);
            return result;
        }

        public BaseBusinessServices(IHttpClientManager httpClientManager, IConfiguration configuration)
        {
            _httpClientManager = httpClientManager;
            _configuration = configuration;
        }

        public abstract void SetApiEndpointAddress();

        public virtual IEnumerable<T> GetAll()
        {
            var result = Task.Run(async () => await GetAllAsync()).Result;
            return result;
        }
        public async Task<T> Get()
        {
            SetupApiAddress();
            var result = await _httpClientManager.GetAsync<T>(ApiEndPoint);
            return result;
        }
        public async Task<T> PostAsync(object data, string token = null)
        {
            SetupApiAddress();
            //var result = await _httpClientManager.GetAsync<T>(ApiEndPoint);
            var result = await _httpClientManager.PostAsync<T>(ApiEndPoint,data,token);
            return result;
        }

    }
}
