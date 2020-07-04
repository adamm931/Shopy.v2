using Shopy.Application.Models;
using Shopy.Client.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Clients
{
    internal class SizesApi : ISizesApi
    {
        private readonly ShopyHttpClient _client;

        public SizesApi(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<SizeResponse>> ListAsync()
            => await _client.GetAsync<IEnumerable<SizeResponse>>("sizes");
    }
}