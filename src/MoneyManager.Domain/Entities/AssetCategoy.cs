namespace MoneyManager.Domain.Entities
{
    public class AssetCategoy
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public AssetCategoy Parent { get; private set; }

        public double Allocation { get; private set; }

        public int SortOrder { get; private set; }
    }
}
