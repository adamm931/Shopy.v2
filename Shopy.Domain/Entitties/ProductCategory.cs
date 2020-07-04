using Shopy.Domain.Entitties.Base;
using System;

namespace Shopy.Domain.Entitties
{
    public class ProductCategory : Entity
    {
        public Product Product { get; private set; }

        internal int ProductId { get; private set; }

        public Category Category { get; private set; }

        internal int CategoryId { get; private set; }

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
