using System;

namespace Shopy.Domain.Entitties.Base
{
    public abstract class Entity<TId>
    {
        public TId Id { get; private set; }

        public Guid ExternalId { get; protected set; }

        protected Entity()
        {
        }
    }
}
