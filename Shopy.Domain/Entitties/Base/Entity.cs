using System;

namespace Shopy.Domain.Entitties.Base
{
    public abstract class Entity : Entity<Guid>
    {
        public Entity()
        {
            ExternalId = Guid.NewGuid();
        }
    }
}
