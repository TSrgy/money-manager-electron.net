using MoneyManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Asset : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AssetType Type { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Value { get; set; }
        public AssetValueChangeType ValueChangeType { get; set; }
        public decimal ValueChangeRate { get; set; }
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
