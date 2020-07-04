using Shopy.Application.Categories.Add;
using Shopy.Application.Categories.Edit;
using Shopy.Application.Models;
using Shopy.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Clients
{
    internal class CategoriesApi : ICategoriesApi
    {
        private readonly IShopyHttpClient _client;

        public CategoriesApi(IShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<LookupResponse>> LookupAsync()
            => await _client.GetAsync<IEnumerable<LookupResponse>>("categories/lookup");

        public async Task<CategoryReponse> GetAsync(Guid ExternalId)
            => await _client.GetAsync<CategoryReponse>($"categories/{ExternalId}/get");

        public async Task<Guid> AddAsync(AddCategoryCommand category)
            => await _client.PostAsync<AddCategoryCommand, Guid>("categories/add", category);

        public async Task EditAsync(EditCategoryCommand category)
            => await _client.PutAsync($"categories/edit", category);

        public async Task DeleteAsync(Guid ExternalId)
            => await _client.DeleteAsync($"categories/{ExternalId}/delete");
    }
}