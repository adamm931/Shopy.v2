using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Enums;
using System;

namespace Shopy.Domain.Entitties
{
    public class AuditLogEntry : Entity
    {
        public Guid? EntityExternalId { get; set; }

        public string Changes { get; set; }

        public string ColumnValues { get; set; }

        public string ByUser { get; set; }

        public DateTime Date { get; set; }

        public AuditLogEntryTable Table { get; set; }

        public AuditLogEntryAction Action { get; set; }
    }
}
