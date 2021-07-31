using MoneyManager.Domain.Common;

namespace MoneyManager.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }
    }
}
