using MoneyManager.Domain.Common;

namespace MoneyManager.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public long Id { get; set; }
    }
}
