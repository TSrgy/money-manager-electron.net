using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class BudgetTable
    {
        public long Id { get; set; }
        public BudgetYear BudgetYear { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
    }
}
