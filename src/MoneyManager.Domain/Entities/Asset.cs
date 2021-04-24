using MoneyManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Asset : AuditableEntity
    {
        public long Id { get; private set; }

        public string Name { get; init; }

        public AssetType Type { get; private set; }

        public DateTime StartDate { get; init; }

        public decimal Value { get; init; }

        public AssetValueChangeType ValueChangeType { get; private set; }

        public decimal ValueChangeRate { get; private set; }

        public string  Notes { get; set; }
    }

    public enum AssetType
    {
        Cash = 0,
        Property = 1,
        Automobile = 2,
        HouseholdObject = 3,
        Art = 4,
        Jewellery = 5,
        Other = 6
    }

    public enum AssetValueChangeType
    {
        None = 0,
        Appreciates = 1,
        Depreciates = 2
    }
}
