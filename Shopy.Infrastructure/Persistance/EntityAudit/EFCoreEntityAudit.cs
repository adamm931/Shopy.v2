using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopy.Application.Interfaces;
using Shopy.Common;
using Shopy.Common.Interfaces;
using Shopy.Domain.Entitties.Base;
using System.Linq;

namespace Shopy.Infrastructure.Persistance.EntityAudit
{
    internal class EfCoreEntityAudit : IEfCoreEntityAudit
    {
        private readonly IAuthProvider _authProvider;
        private readonly IDateTime _dateTime;

        public EfCoreEntityAudit(IAuthProvider authProvider, IDateTime dateTime)
        {
            _authProvider = authProvider;
            _dateTime = dateTime;
        }

        public void Audit(ChangeTracker changeTracker)
        {
            var user = _authProvider.User;
            var now = _dateTime.Now;

            changeTracker
                .Entries()
                .Where(entry => typeof(AuditEntity).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Added)
                .ForEach(entry =>
                {
                    var auditEntity = (AuditEntity)entry.Entity;

                    auditEntity.SetCreatedOn(now);
                    auditEntity.SetCreatedBy(user);
                });

            changeTracker
                .Entries()
                .Where(entry => typeof(AuditEntity).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Modified)
                .ForEach(entry =>
                {
                    var auditEntity = (AuditEntity)entry.Entity;

                    auditEntity.SetModifiedOn(now);
                    auditEntity.SetModifiedBy(user);
                });
        }
    }
}
