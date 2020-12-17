using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? LastModified { get; set; }
    }
}
