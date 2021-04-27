using MoneyManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Accounts.Any())
            {
                context.Accounts.Add(new Account
                {
                    Name = "First",
                });

                context.Accounts.Add(new Account
                {
                    Name = "Second",
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
