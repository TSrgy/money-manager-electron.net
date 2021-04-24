using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests
{
    [CollectionDefinition("Database collection")]
    public partial class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
