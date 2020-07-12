using Shopy.Common;
using Shopy.Domain.Entitties.Base;
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
            ExternalId = Guid.NewGuid();

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
            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }

        public void UpdateBrand(Brand brand)
        {
            Brand = brand;
        }

        public void AddCategory(Category categoryToAdd)
        {
            if (_categories.Any(productCategory => productCategory.HasCategory(categoryToAdd.ExternalId)))
            {
                return;
            }

            _categories.Add(new ProductCategory(this, categoryToAdd));
        }

        public void RemoveCategory(Guid externalId)
        {
            _categories.RemoveAll(productCategory => !productCategory.HasCategory(externalId));
        }

        public void AddSizes(IEnumerable<Size> size)
        {
            foreach (var sizeCode in size)
            {
                AddSize(sizeCode);
            }
        }

        public void AddSize(Size size)
        {
            if (_sizes.Any(productSize => productSize.Size.Code == size.Code))
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