using Xunit;

namespace Application.IntegrationTests
{
    [CollectionDefinition("Database collection")]
    public partial class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
