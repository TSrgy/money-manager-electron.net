using MoneyManager.Application.Common.Mappings;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Application.Assets.Queries
{
    public class AssetDto : IMapFrom<Asset>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
