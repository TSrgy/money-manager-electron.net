using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Currency
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string PfxSymbol { get; private set; }
        public string SfxSymbol { get; private set; }
        public string DecimalPoint { get; private set; }
        public string GroupSeparator { get; private set; }
        public int Scale { get; private set; }
        public string CurrencySymbol { get; private set; }
        public string CurrencyType { get; private set; }
        public int Historic { get; private set; }

    }
}
