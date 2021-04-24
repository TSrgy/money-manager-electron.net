using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class BudgetTable
    {
        public long Id { get; private set; }

        public BudgetYear BudgetYear { get; private set; }

        public Category Category { get; private set; }

        public Subcategory Subcategory { get; private set; }

        public string Period { get; private set; }

        public decimal Amount { get; private set; }
    }
}
