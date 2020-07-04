using Shopy.Application.Models;
using Shopy.Client.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Clients
{
    internal class BrandsApi : IBrandsApi
    {
        private readonly ShopyHttpClient _client;

        public BrandsApi(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<BrandResponse>> ListAsync()
            => await _client.GetAsync<IEnumerable<BrandResponse>>("brands");
    }
}