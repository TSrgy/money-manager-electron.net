using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Currency
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PfxSymbol { get; set; }
        public string SfxSymbol { get; set; }
        public string DecimalPoint { get; set; }
        public string GroupSeparator { get; set; }
        public int Scale { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyType { get; set; }
        public int Historic { get; set; }

    }
}
