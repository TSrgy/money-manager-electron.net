using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class AssetCategoy
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AssetCategoy Parent { get; set; }
        public double Allocation { get; set; }
        public int SortOrder { get; set; }
    }
}
