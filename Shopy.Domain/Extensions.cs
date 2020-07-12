using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain
{
    public static class Extensions
    {
        public static void Delete(this ISoftDelete entity)
        {
            entity.GetType()
                .GetProperty(nameof(ISoftDelete.Deleted))
                .SetValue(null, true);
        }
    }
}
