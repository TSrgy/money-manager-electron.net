using System;
using System.Threading.Tasks;
using FluentAssertions;
using MoneyManager.Application.Assets.Commands.CreateAsset;
using MoneyManager.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.Assets.Commands
{
    [Collection("Database collection")]
    public class CreateAssetCommandTests : TestBase
    {
        public CreateAssetCommandTests(DatabaseFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task ShouldCreateAssetAsync()
        {
            var command = new CreateAssetCommand
            {
                Name = "test",
                Value = 100
            };

            var id = await Fixture.SendAsync(command);

            var asset = await Fixture.FindAsync<Asset>(id);

            asset.Should().NotBeNull();
            asset.Name.Should().Be(command.Name);
            asset.Value.Should().Be(command.Value);
            asset.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
