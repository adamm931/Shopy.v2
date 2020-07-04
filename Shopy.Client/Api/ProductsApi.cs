using Shopy.Application.Models;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.List;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Application.Products.UploadImage;
using Shopy.Client.Extensions;
using Shopy.Client.Interfaces;
using System;
using System.Threading.Tasks;

namespace Shopy.Client.Clients
{
    internal class ProductsApi : IProductsApi
    {
        private readonly IShopyHttpClient _client;

        public ProductsApi(IShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<PagedList<ProductResponse>> ListAsync(ListProductsQuery request = null)
            => await _client.GetAsync<PagedList<ProductResponse>>($"products/{request.ToQueryString()}");

        public async Task<ProductResponse> GetAsync(Guid ExternalId)
            => await _client.GetAsync<ProductResponse>($"products/{ExternalId}/get");

        public async Task<ProductDetailsResponse> GetDetailsAsync(Guid ExternalId)
            => await _client.GetAsync<ProductDetailsResponse>($"products/{ExternalId}/details");

        public async Task<Guid> AddAsync(AddProductCommand command)
            => await _client.PostAsync<AddProductCommand, Guid>("products/add", command);

        public async Task EditAsync(EditProductCommand command)
            => await _client.PutAsync($"products/edit", command);

        public async Task DeleteProductAsync(Guid ExternalId)
            => await _client.DeleteAsync($"products/{ExternalId}/delete");

        public async Task RemoveFromCategoryAsync(RemoveProductFromCategoryCommand command)
            => await _client.PostAsync($"products/remove-from-category", command);

        public async Task AddToCategoryAsync(AddProductToCategoryCommand command)
            => await _client.PostAsync($"products/add-to-category", command);

        public async Task UploadImageAsync(UploadProductImageCommand command)
            => await _client.PostAsync<UploadProductImageCommand>("products/uploadImage");
    }
}