using Audit.Core;
using Audit.EntityFramework;
using Microsoft.Extensions.Options;
using Shopy.Application.Interfaces;
using Shopy.Common.Extensions;
using Shopy.Common.Interfaces;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using Shopy.Domain.Entitties.Base;
using System;
using Configuration = Audit.Core.Configuration;

namespace Shopy.Infrastructure.Persistance.Context
{
    public class ShopyAuditCofigurer : IAuditConfigurer
    {
        private readonly IDateTime dateTime;
        private readonly IAuthService authProvider;
        private readonly IOptions<ShopyDatabaseOptions> dbOptions;

        public ShopyAuditCofigurer(
            IDateTime dateTime,
            IAuthService authProvider,
            IOptions<ShopyDatabaseOptions> dbOptions,
            IRepository<AuditLogEntry> auditLogEntries,
            IUnitOfWork unitOfWork)
        {
            this.dateTime = dateTime;
            this.authProvider = authProvider;
            this.dbOptions = dbOptions;
        }

        public void ConfigureAudit()
        {
            Configuration.Setup()
                .UseEntityFramework(config => config
                    .UseDbContext<ShopyDbContext>(dbOptions)
                    .AuditTypeMapper(type => typeof(AuditLogEntry))
                        .AuditEntityAction<AuditLogEntry>((@event, entry, audit) => ApplyAudit(audit, entry))
                        .IgnoreMatchedProperties()
                );
        }

        private TType ReadColumn<TType>(EventEntry eventEntry, string name)
            => !eventEntry.ColumnValues.TryGetValue(name, out object externalId)
                ? default
                : (TType)externalId;

        private void ApplyAudit(AuditLogEntry audit, EventEntry @event)
        {
            audit.ColumnValues = @event.ColumnValues.ToJson();
            audit.Changes = @event.Changes.ToJson();
            audit.Date = dateTime.Now;
            audit.ByUser = authProvider.User;
            audit.Action = @event.Action;
            audit.Table = @event.Table;
            audit.EntityExternalId = ReadColumn<Guid?>(@event, nameof(Entity.ExternalId));

            //var externalId = ReadColumn<Guid?>(@event, nameof(Entity.ExternalId));

            //if (externalId.HasValue)
            //{
            //    audit.ColumnValues = @event.ColumnValues.ToJson();
            //    audit.Changes = @event.Changes.ToJson();
            //    audit.Date = dateTime.Now;
            //    audit.ByUser = authProvider.User;
            //    audit.Action = @event.Action;
            //    audit.Table = @event.Table;
            //    audit.EntityExternalId = externalId;

            //    return true;
            //}

            //var id = ReadColumn<long>(@event, "Id");

            //if (id == default)
            //{
            //    return false;
            //}

            //var currentLogs = auditLogEntries.List().Result;

            //var logForId = currentLogs.FirstOrDefault(log => log.ColumnValues.Contains($"\"Id\":{id}"));

            //if (logForId == null)
            //{
            //    return true;
            //}

            //var columns = logForId.ColumnValues.FromJson<IDictionary<string, object>>();

            //foreach (var item in @event.ColumnValues)
            //{
            //    columns.Add(item);
            //}

            //logForId.ColumnValues = columns.ToJson();

            //unitOfWork.Save().Wait();

            //return false;
        }
    }
}
