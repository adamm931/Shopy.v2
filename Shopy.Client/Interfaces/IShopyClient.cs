using Shopy.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Contracts
{
    public interface IShopyClient
    {
        Task<IEnumerable<CategoryLookup>> LookupCategories();

        Task<IEnumerable<Category>> ListCategories();

        Task<Category> GetCategory(Guid uid);

        Task<Category> AddCategory(Category category);

        Task EditCategory(Category category);

        Task DeleteCategory(Guid uid);

        Task<ProductListResponse> ListProducts(ProductFilter filter = null);

        Task<ProductDetails> GetProductDetails(Guid uid);

        Task<Product> GetProduct(Guid uid);

        Task AddProduct(AddEditProduct product);

        Task EditProduct(AddEditProduct product);

        Task AddProductToCategory(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategory(Guid productUid, Guid categoryUid);

        Task DeleteProduct(Guid uid);

        Task<IEnumerable<Size>> ListSizes();

        Task<IEnumerable<Brand>> ListBrands();
    }
}
