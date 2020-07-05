using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Shopy.Infrastructure.Persistance.EntityAudit
{
    public interface IEfCoreEntityAudit
    {
        void Audit(ChangeTracker changeTracker);
    }
}
