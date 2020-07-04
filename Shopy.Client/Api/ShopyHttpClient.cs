using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopy.Client.Config;
using Shopy.Client.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Client.Clients
{
    internal class ShopyHttpClient : IShopyHttpClient
    {
        private readonly HttpClient _httpClient;

        public ShopyHttpClient(HttpClient httpClient, IOptions<ShopyClientOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.ApiUrl);
        }

        public async Task<T> GetAsync<T>(string requestPath)
        {
            return await SendAsync<object, T>(requestPath, HttpMethod.Get);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string requestPath, TRequest content = null)
            where TRequest : class
        {
            return await SendAsync<TRequest, TResult>(requestPath, HttpMethod.Post, content);
        }

        public async Task PostAsync<TRequest>(string requestPath, TRequest content = null) where TRequest : class
        {
            await SendAsync<TRequest, object>(requestPath, HttpMethod.Post, content);
        }

        public async Task PostAsync(string requestPath)
        {
            await SendAsync<object, object>(requestPath, HttpMethod.Post);
        }

        public async Task PutAsync<TRequest>(string requestPath, TRequest content)
            where TRequest : class
        {
            await SendAsync<TRequest, object>(requestPath, HttpMethod.Put, content);
        }

        public async Task DeleteAsync(string requestPath)
        {
            await SendAsync<object, object>(requestPath, HttpMethod.Delete);
        }

        private async Task<TResult> SendAsync<TRequest, TResult>(
            string requestPath, HttpMethod method, TRequest content = null)
            where TRequest : class
        {
            var request = new HttpRequestMessage(method, requestPath);

            if (content != null)
            {
                var serializedContent = JsonConvert.SerializeObject(content);
                request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);

            if (response == null)
            {
                return default;
            }

            var stream = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(stream);

            return result;
        }
    }
}