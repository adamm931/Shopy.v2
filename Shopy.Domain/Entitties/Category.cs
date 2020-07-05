using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties
{
    public class Category : AuditEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<ProductCategory> ProductCategories { get; private set; }

        public Category(string name, string description)
        {
            ExternalId = Guid.NewGuid();

            Name = name;
            Description = description;

            ProductCategories = new List<ProductCategory>();
        }

        private Category()
        {
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}