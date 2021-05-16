using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!await context.Currencies.AnyAsync())
            {
                await context.Currencies.AddRangeAsync(new[]
                {
                    new Currency("Euro", "EUR")
                    {
                        PfxSymbol = "€"
                    },
                    new Currency("US Dollar", "USD")
                    {
                        PfxSymbol = "$"
                    },
                    new Currency("Russian Ruble", "RUB")
                    {
                        SfxSymbol = "р"
                    }
                });

                await context.SaveChangesAsync();
            }

            var usd = await context.Currencies.SingleAsync(x => x.TickerSymbol == "USD");

            if (!context.Accounts.Any())
            {
                await context.Accounts.AddRangeAsync(new[]
                {
                    new Account("First", AccountType.Checking, 0, usd),
                    new Account("Second", AccountType.Checking, 100, usd)
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
