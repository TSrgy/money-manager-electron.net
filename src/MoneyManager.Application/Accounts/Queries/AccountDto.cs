using MoneyManager.Application.Common.Mappings;
using MoneyManager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Application.Accounts.Queries
{
    public class AccountDto : IMapFrom<Account>
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
