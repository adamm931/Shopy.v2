using Shopy.Common;
using Shopy.Common.Extensions;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Domain.Entitties
{
    public class Product : AuditEntity, ISoftDelete
    {
        private readonly List<ProductSize> _sizes = new List<ProductSize>();

        private readonly List<ProductCategory> _categories = new List<ProductCategory>();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public Brand Brand { get; private set; }

        public bool Deleted { get; private set; }

        public IReadOnlyCollection<ProductSize> Sizes => _sizes.AsReadOnly();

        public IReadOnlyCollection<ProductCategory> Categories => _categories.AsReadOnly();

        public Product(string name, string description, decimal price, Brand brand, IEnumerable<Size> sizes)
        {
            UpdateName(name);
            UpdateDescription(description);
            UpdatePrice(price);
            UpdateBrand(brand);
            AddSizes(sizes);
        }

        private Product()
        {
        }

        public void UpdateName(string name)
        {
            Param.Ensure.NotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Param.Ensure.NotNullOrEmpty(description, nameof(description));

            Description = description;
        }

        public void UpdatePrice(decimal price)
        {
            Param.Ensure.GreaterThan(price, 0, nameof(price));

            Price = price;
        }

        public void UpdateBrand(Brand brand)
        {
            Param.Ensure.NotNull(brand, nameof(brand));

            Brand = brand;
        }

        public void AddCategory(Category category)
        {
            Param.Ensure.NotNull(category, nameof(category));

            if (_categories.Any(productCategory => productCategory.HasCategory(category.ExternalId)))
            {
                return;
            }

            _categories.Add(new ProductCategory(this, category));
        }

        public void RemoveCategory(Guid externalId)
        {
            Param.Ensure.NotEmpty(externalId, nameof(externalId));

            _categories.RemoveAll(productCategory => !productCategory.HasCategory(externalId));
        }

        public void AddSizes(IEnumerable<Size> sizes)
        {
            Param.Ensure.NotNull(sizes, nameof(sizes));

            foreach (var sizeCode in sizes)
            {
                AddSize(sizeCode);
            }
        }

        public void AddSize(Size size)
        {
            Param.Ensure.NotNull(size, nameof(size));

            if (_sizes.Any(productSize => productSize.Size.Name == size.Name))
            {
                return;
            }

            _sizes.Add(new ProductSize(this, size));
        }

        public IEnumerable<Product> GetRelatedProducts()
        {
            const int RelatedProductsLimit = 4;

            return Categories
                .SelectMany(productCategory => productCategory.Category.Products)
                .Select(category => category.Product)
                .Where(product => product.ExternalId != ExternalId)
                .Randomize()
                .Take(RelatedProductsLimit);
        }
    }
}