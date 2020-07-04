using Shopy.Common;
using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Domain.Entitties
{
    public class Product : Entity
    {
        private IEnumerable<Product> _relatedProducts;

        private const int RelatedProductsLimit = 4;

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int BrandId { get; private set; }

        public Brand Brand { get; private set; }

        public ICollection<ProductSize> ProductSizes { get; private set; }

        public ICollection<ProductCategory> ProductCategories { get; private set; }

        public IEnumerable<Product> RelatedProducts => _relatedProducts ??= GetRelatedProducts();

        public Product(string name, string description, decimal price)
        {
            ExternalId = Guid.NewGuid();

            Name = name;
            Description = description;
            Price = price;

            ProductSizes = new List<ProductSize>();
            ProductCategories = new List<ProductCategory>();
        }

        private Product()
        {
        }

        public void Update(
            string name,
            string description,
            decimal price,
            Brand brandType,
            IEnumerable<Size> sizeTypes)
        {
            Name = name;
            Description = description;
            Price = price;

            SetBrand(brandType);

            foreach (var sizeType in sizeTypes)
            {
                AddSize(sizeType);
            }
        }

        public void SetBrand(Brand brandType)
        {
            Brand = brandType;
        }

        public void AddCategory(Category categoryToAdd)
        {
            if (ProductCategories.Any(productCategory => productCategory.HasCategory(categoryToAdd.ExternalId)))
            {
                return;
            }

            ProductCategories.Add(new ProductCategory(this, categoryToAdd));
        }

        public void RemoveCategory(Guid externalId)
        {
            ProductCategories.RemoveAll(productCategory => !productCategory.HasCategory(externalId));
        }

        public void AddSize(Size size)
        {
            if (ProductSizes.Any(productSize => productSize.ExternalId == size.ExternalId))
            {
                return;
            }

            ProductSizes.Add(new ProductSize(this, size));
        }

        private IEnumerable<Product> GetRelatedProducts()
        {
            return ProductCategories
                .SelectMany(productCategory => productCategory.Category.ProductCategories)
                .Select(category => category.Product)
                .Where(product => product.ExternalId != ExternalId)
                .Randomize()
                .Take(RelatedProductsLimit);
        }
    }
}