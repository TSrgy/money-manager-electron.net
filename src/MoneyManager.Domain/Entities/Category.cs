using MoneyManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
    }
}
