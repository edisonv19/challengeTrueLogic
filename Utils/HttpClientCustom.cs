using Infrastructure.Utils.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public class HttpClientCustom : IHttpClientCustom
    {
        private readonly HttpClient _httpClient;

        public HttpClientCustom()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
