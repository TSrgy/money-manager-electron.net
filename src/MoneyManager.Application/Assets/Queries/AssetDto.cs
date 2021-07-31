using MoneyManager.Application.Common.Mappings;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Assets.Queries
{
    public class AssetDto : IMapFrom<Asset>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
