using System;

namespace MoneyManager.Domain.Entities
{
    public class CurrencyHistory
    {
        public long Id { get; private set; }

        public Currency Currency { get; private set; }

        public DateTime Date { get; private set; }

        public decimal Value { get; private set; }

        public int CurrUpdType { get; private set; }
    }
}
