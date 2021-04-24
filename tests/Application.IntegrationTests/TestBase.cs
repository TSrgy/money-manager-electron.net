using Xunit;

namespace Application.IntegrationTests
{

    [Collection("Database collection")]
    public abstract class TestBase
    {
        public TestBase(DatabaseFixture fixture)
        {
            fixture.ResetState();
            Fixture = fixture;
        }

        protected DatabaseFixture Fixture { get; }
    }
}
