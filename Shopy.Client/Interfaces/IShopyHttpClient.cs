using System.Threading.Tasks;

namespace Shopy.Client.Interfaces
{
    internal interface IShopyHttpClient
    {
        Task<TResult> GetAsync<TResult>(string requestPath);

        Task<TResult> PostAsync<TRequest, TResult>(string requestPath, TRequest content = null) where TRequest : class;

        Task PostAsync<TRequest>(string requestPath, TRequest content = null) where TRequest : class;

        Task PostAsync(string requestPath);

        Task PutAsync<TRequest>(string requestPath, TRequest content) where TRequest : class;

        Task DeleteAsync(string requestPath);
    }
}
