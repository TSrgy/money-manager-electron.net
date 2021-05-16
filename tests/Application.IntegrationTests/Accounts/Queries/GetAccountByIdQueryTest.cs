using FluentAssertions;
using MoneyManager.Application.Accounts.Queries;
using MoneyManager.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.Accounts.Queries
{
    [Collection("Database collection")]
    public class GetAccountByIdQueryTest : TestBase
    {
        public GetAccountByIdQueryTest(DatabaseFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task ShouldReturnTheAccount()
        {
            var name = "test1";

            var account = new Account(name, AccountType.Checking, 0, new Currency("test", "TST"));

            await Fixture.AddAsync(account);

            var query = new GetAccountByIdQuery()
            {
                Id = account.Id
            };

            var accountDto = await Fixture.SendAsync(query);

            accountDto.Name.Should().Be(name);
            accountDto.Id.Should().Be(account.Id);
        }
    }
}
