using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Utils
{
    public interface IApiManager
    {
        Task<T> GetSynch<T>(string controller, string action = null, Dictionary<string, string> data = null, bool keyValuPairFlag = false);
        T PostAsync<T>(string controller, string action, object data);
        T PostExternalAsync<T>(string controller, string action, object data, string token);
    }
}
