using Microsoft.EntityFrameworkCore;
using Shopy.Application.Interfaces;
using Shopy.Common;
using Shopy.Common.Interfaces;
using Shopy.Domain.Entitties.Base;
using Shopy.Infrastructure.Interfaces;

namespace Shopy.Infrastructure.Persistance.OnSaveHandlers
{
    internal class EntityAuditHandler : IOnSaveHandler
    {
        private readonly IAuthProvider _authProvider;
        private readonly IDateTime _dateTime;

        public EntityAuditHandler(IAuthProvider authProvider, IDateTime dateTime)
        {
            _authProvider = authProvider;
            _dateTime = dateTime;
        }

        public void OnSave(DbContext context)
        {
            var user = _authProvider.User;
            var now = _dateTime.Now;
            var changeTracker = context.ChangeTracker;

            changeTracker
                .EntriesByState(EntityState.Added)
                .OfType<AuditEntity>()
                .Each(entry =>
                {
                    var auditEntity = (AuditEntity)entry.Entity;

                    auditEntity.SetCreatedOn(now);
                    auditEntity.SetCreatedBy(user);
                });

            changeTracker
                .EntriesByState(EntityState.Modified)
                .OfType<AuditEntity>()
                .Each(entry =>
                {
                    var auditEntity = (AuditEntity)entry.Entity;

                    auditEntity.SetModifiedOn(now);
                    auditEntity.SetModifiedBy(user);
                });
        }
    }
}
