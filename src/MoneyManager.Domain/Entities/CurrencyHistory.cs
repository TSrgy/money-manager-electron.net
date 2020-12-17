using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class CurrencyHistory
    {
        public long Id { get; set; }

        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int CurrUpdType { get; set; }
    }
}
