namespace MoneyManager.Domain.Entities
{
    public class Currency
    {
        public Currency(string name, string tickerSymbol)
        {
            Name = name;
            TickerSymbol = tickerSymbol;
        }

        private Currency()
        {
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string PfxSymbol { get; init; }

        public string SfxSymbol { get; init; }

        public string DecimalPoint { get; init; } = ".";

        public string GroupSeparator { get; init; } = " ";

        public int Scale { get; init; } = 100;

        public string TickerSymbol { get; private set; }

        public CurrencyType CurrencyType { get; init; } = CurrencyType.Traditional;
    }

    public enum CurrencyType : int
    {
        /// <summary>
        /// Traditional currency type.
        /// </summary>
        Traditional = 0,

        /// <summary>
        /// Cryptocurrency.
        /// </summary>
        Crypto = 1
    }
}
