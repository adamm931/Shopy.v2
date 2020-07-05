using Shopy.Common;
using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Domain.Entitties
{
    public class Product : AuditEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public Brand Brand { get; private set; }

        public ICollection<ProductSize> ProductSizes { get; private set; }

        public ICollection<ProductCategory> ProductCategories { get; private set; }

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
            if (ProductSizes.Any(productSize => productSize.Size.ExternalId == size.ExternalId))
            {
                return;
            }

            ProductSizes.Add(new ProductSize(this, size));
        }

        public IEnumerable<Product> GetRelatedProducts()
        {
            const int RelatedProductsLimit = 4;

            return ProductCategories
                .SelectMany(productCategory => productCategory.Category.ProductCategories)
                .Select(category => category.Product)
                .Where(product => product.ExternalId != ExternalId)
                .Randomize()
                .Take(RelatedProductsLimit);
        }
    }
}