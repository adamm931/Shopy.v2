using System;

namespace Shopy.Domain.Entitties.Base
{
    public abstract class AuditEntity : Entity
    {
        public DateTime CreatedOn { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public string ModifiedBy { get; private set; }

        public void SetCreatedOn(DateTime createdOn)
        {
            CreatedOn = createdOn;
        }

        public void SetCreatedBy(string createdBy)
        {
            CreatedBy = createdBy;
        }

        public void SetModifiedOn(DateTime modifiedOn)
        {
            ModifiedOn = modifiedOn;
        }

        public void SetModifiedBy(string modifiedBy)
        {
            ModifiedBy = modifiedBy;
        }
    }
}
