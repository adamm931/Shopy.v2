namespace Shopy.Domain.Entitties.Base
{
    public abstract class Entity<TId>
    {
        public TId ExternalId { get; protected set; }

        protected Entity()
        {
        }
    }
}
