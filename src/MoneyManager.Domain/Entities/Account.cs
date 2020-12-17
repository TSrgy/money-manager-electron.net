using MoneyManager.Domain.Common;
using System;

namespace MoneyManager.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public string Num { get; set; }
        public AccountStatus Status { get; set; }
        public string Notes { get; set; }
        public string Heldat { get; set; }
        public string Website { get; set; }
        public string ContactInfo { get; set; }
        public string AccessInfo { get; set; }
        public decimal InitialBalance { get; set; }
        public string FavoriteAcct { get; set; }
        public Currency Currency { get; set; }
        public int StatementLocked { get; set; } //TODO What is it
        public DateTime StatementDate { get; set; } //TODO What is it
        public decimal MinBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal InterestRate { get; set; } //TODO What is it
        public DateTime PaymentDueDate { get; set; } //TODO What is it
        public decimal MinPayment { get; set; }

    }

    public enum AccountStatus
    {
        Closed = 0,
        Open = 1
    }

    public enum AccountType
    {
        Checking = 0,
        Term = 1,
        Investment = 2,
        CreditCard = 3
    }
}
