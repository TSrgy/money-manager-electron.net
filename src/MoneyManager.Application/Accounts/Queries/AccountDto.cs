using MoneyManager.Application.Common.Mappings;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Accounts.Queries
{
    public class AccountDto : IMapFrom<Account>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
