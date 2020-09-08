using Microsoft.EntityFrameworkCore;
using Shopy.Application.Interfaces;
using Shopy.Common.Extensions;
using Shopy.Common.Interfaces;
using Shopy.Domain.Entitties.Base;
using Shopy.Infrastructure.Interfaces;

namespace Shopy.Infrastructure.Persistance.OnSaveHandlers
{
    internal class EntityAuditHandler : IOnSaveHandler
    {
        private readonly IAuthService _authProvider;
        private readonly IDateTime _dateTime;

        public EntityAuditHandler(IAuthService authProvider, IDateTime dateTime)
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
                .EntityEntriesByState<AuditEntity>(EntityState.Added)
                .Each(entry =>
                {
                    entry.Entity.SetCreatedOn(now);
                    entry.Entity.SetCreatedBy(user);
                });

            changeTracker
                .EntityEntriesByState<AuditEntity>(EntityState.Modified)
                .Each(entry =>
                {
                    entry.Entity.SetModifiedOn(now);
                    entry.Entity.SetModifiedBy(user);
                });
        }
    }
}
