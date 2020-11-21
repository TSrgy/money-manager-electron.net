using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
