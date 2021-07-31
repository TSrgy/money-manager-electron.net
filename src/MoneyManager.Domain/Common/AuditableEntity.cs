using System;

namespace MoneyManager.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? LastModified { get; set; }
    }
}
