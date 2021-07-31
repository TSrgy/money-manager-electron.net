using MoneyManager.Domain.Common;

namespace MoneyManager.Domain.Entities
{
    public class Subcategory : AuditableEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }
    }
}
