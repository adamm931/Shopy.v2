using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class AuditLogEntryAction : BaseEnum<AuditLogEntryAction>
    {
        public static AuditLogEntryAction Insert => new AuditLogEntryAction("Insert");

        public static AuditLogEntryAction Update => new AuditLogEntryAction("Update");

        public static AuditLogEntryAction Delete => new AuditLogEntryAction("Delete");

        private AuditLogEntryAction(string name) : base(name) { }

        private AuditLogEntryAction() { }

        public static implicit operator AuditLogEntryAction(string name) => Parse(name);
    }
}
