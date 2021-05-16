using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }

        DbSet<Asset> Assets { get; set; }

        DbSet<Currency> Currencies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
