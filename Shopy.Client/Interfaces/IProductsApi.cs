using Shopy.Application.Models;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.List;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Application.Products.UploadImage;
using Shopy.Common.Paging;
using System;
using System.Threading.Tasks;

namespace Shopy.Client.Interfaces
{
    public interface IProductsApi
    {
        Task<IPagedList<ProductResponse>> ListAsync(ListProductsQuery query = null);

        Task<ProductResponse> GetAsync(Guid ExternalId);

        Task<ProductDetailsResponse> GetDetailsAsync(Guid ExternalId);

        Task<Guid> AddAsync(AddProductCommand command);

        Task EditAsync(EditProductCommand command);

        Task DeleteProductAsync(Guid ExternalId);

        Task RemoveFromCategoryAsync(RemoveProductFromCategoryCommand command);

        Task AddToCategoryAsync(AddProductToCategoryCommand command);

        Task UploadImageAsync(UploadProductImageCommand command);
    }
}
