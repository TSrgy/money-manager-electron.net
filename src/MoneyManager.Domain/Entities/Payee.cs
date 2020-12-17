using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Payee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
