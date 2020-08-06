using Shopy.Common;
using Shopy.Domain.Entitties.Base;
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
            Update(name, description);
        }

        private Category()
        {
        }

        public void Update(string name, string description)
        {
            Param.Ensure.NotNullOrEmpty(name, nameof(name));
            Param.Ensure.NotNullOrEmpty(description, nameof(description));

            Name = name;
            Description = description;
        }
    }
}