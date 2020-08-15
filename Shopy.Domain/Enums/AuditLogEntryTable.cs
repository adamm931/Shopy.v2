using Shopy.Domain.Entitties.Base;

namespace Shopy.Domain.Enums
{
    public class AuditLogEntryTable : BaseEnum<AuditLogEntryTable>
    {
        public static AuditLogEntryTable Product => new AuditLogEntryTable("Product");

        public static AuditLogEntryTable ProductSize => new AuditLogEntryTable("ProductSize");

        public static AuditLogEntryTable Category => new AuditLogEntryTable("Category");

        public static AuditLogEntryTable User => new AuditLogEntryTable("User");

        public static AuditLogEntryTable ProductCategory => new AuditLogEntryTable("ProductCategory");

        public static AuditLogEntryTable UserCredentials => new AuditLogEntryTable("UserCredentials");

        private AuditLogEntryTable(string name) : base(name) { }

        private AuditLogEntryTable() { }

        public static implicit operator AuditLogEntryTable(string name) => Parse(name);

    }
}
