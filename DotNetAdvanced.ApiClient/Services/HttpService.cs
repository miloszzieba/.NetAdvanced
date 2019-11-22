using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.ApiClient.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public HttpService(HttpClient httpClient, string apiUrl)
        {
            this._httpClient = httpClient;
            this._apiUrl = apiUrl;
        }

        public T Get<T>(string controllerAction)
        {
            var url = Path.Combine(_apiUrl, controllerAction);
            var httpResponse = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public T Post<T, TBody>(string controllerAction, TBody body)
        {
            var url = Path.Combine(_apiUrl, controllerAction);
            var bodyString = JsonConvert.SerializeObject(body);
            var stringContent = new StringContent(bodyString);
            var httpResponse = _httpClient.PostAsync(url, stringContent).GetAwaiter().GetResult();
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
