using System;

namespace Shopy.Domain.Entitties
{
    public class ProductCategory
    {
        public Product Product { get; private set; }

        public Category Category { get; private set; }

        public ProductCategory(Product product, Category category)
        {
            Product = product;
            Category = category;
        }

        private ProductCategory()
        { }

        public bool HasCategory(Guid categoryExternalId) => Category.ExternalId == categoryExternalId;
    }
}
