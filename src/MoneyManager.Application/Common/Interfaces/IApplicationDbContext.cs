using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Asset> Assets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
