using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Transaction
    {
        public long Id { get; private set; }

        public Account FromAccount { get; private set; }

        public Account ToAccount { get; private set; }

        public Payee Payee { get; private set; }

        public TransactionCode Code { get; private set; }

        public decimal Amount { get; private set; }

        public TransactionStatus Status { get; private set; }

        public string Number { get; private set; }

        public string Notes { get; set; }

        public Category Category { get; private set; }

        public Subcategory Subcategory { get; private set; }

        public DateTime Date { get; private set; }

        public int FollowUpId { get; private set; }

        public decimal ToTransAmount { get; private set; }
    }

    public enum TransactionCode
    {
        Withdrawal = 0,
        Deposit = 1,
        Transfer = 2
    }

    public enum TransactionStatus
    {
        None = 0,
        Reconciled = 1,
        Void = 2,
        FollowUp = 3,
        Duplicate = 4
    }
}
