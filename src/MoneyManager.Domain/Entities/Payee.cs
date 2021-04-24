using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Payee
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public Subcategory Subcategory { get; private set; }
    }
}
