using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;

namespace Shopy.Domain.Entitties
{
    public class Category : AuditEntity, ISoftDelete
    {
        private readonly List<ProductCategory> _products = new List<ProductCategory>();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool Deleted { get; private set; }

        public IReadOnlyCollection<ProductCategory> Products => _products.AsReadOnly();

        public Category(string name, string description)
        {
            ExternalId = Guid.NewGuid();

            Name = name;
            Description = description;
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