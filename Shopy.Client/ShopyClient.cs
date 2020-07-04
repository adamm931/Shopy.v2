using Shopy.Client.Contracts;
using Shopy.Client.Helpers;
using Shopy.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client
{
    public class ShopyClient : IShopyClient
    {
        private readonly IProductsApi _products;
        private readonly ICategoriesApi _categories;
        private readonly ISizesApi _sizes;
        private readonly IBrandsApi _brands;

        public ShopyClient(
            IProductsApi productsClient,
            ICategoriesApi categoriesClient,
            ISizesApi sizesClient,
            IBrandsApi brandsClient)
        {
            _products = productsClient;
            _categories = categoriesClient;
            _sizes = sizesClient;
            _brands = brandsClient;
        }

        public async Task<ProductListResponse> ListProducts(ProductFilter filter = null)
        {
            var products = await _products.ListAsync(filter);

            return products;
        }

        public async Task<IEnumerable<Category>> ListCategories()
        {
            return await _categories.ListAsync();
        }

        public async Task<Product> GetProduct(Guid uid)
        {
            return await _products.GetAsync(uid);
        }

        public async Task AddProduct(AddEditProduct product)
        {
            var result = await _products.AddAsync(product);
            product.Uid = result.Uid;
            ImageHelper.SaveImagesFromProduct(product);
        }

        public async Task EditProduct(AddEditProduct product)
        {
            await _products.EditAsync(product);
            ImageHelper.SaveImagesFromProduct(product);
        }

        public async Task AddProductToCategory(Guid productUid, Guid categoryUid)
        {
            await _products.AddToCategoryAsync(productUid, categoryUid);
        }

        public async Task RemoveProductFromCategory(Guid productUid, Guid categoryUid)
        {
            await _products.RemoveFromCategoryAsync(productUid, categoryUid);
        }

        public async Task DeleteProduct(Guid uid)
        {
            await _products.DeleteProductAsync(uid);
            ImageHelper.DeleteImages(uid);
        }

        public async Task<ProductDetails> GetProductDetails(Guid uid)
        {
            var details = await _products.GetDetailsAsync(uid);
            return details;
        }

        public async Task<IEnumerable<Size>> ListSizes()
        {
            return await _sizes.ListAsync();
        }

        public async Task<IEnumerable<Brand>> ListBrands()
        {
            return await _brands.ListAsync();
        }

        public async Task DeleteCategory(Guid uid)
        {
            await _categories.DeleteAsync(uid);
        }

        public async Task<Category> GetCategory(Guid uid)
        {
            return await _categories.GetAsync(uid);
        }

        public async Task<Category> AddCategory(Category category)
        {
            return await _categories.AddAsync(category);
        }

        public async Task EditCategory(Category category)
        {
            await _categories.EditAsync(category);
        }

        public async Task<IEnumerable<CategoryLookup>> LookupCategories()
        {
            return await _categories.LookupAsync();
        }
    }
}
