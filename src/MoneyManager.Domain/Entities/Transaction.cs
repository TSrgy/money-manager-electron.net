using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Domain.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public Payee Payee { get; set; }
        public TransactionCode Code { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public DateTime Date { get; set; }
        public int FollowUpId { get; set; }
        public decimal ToTransAmount { get; set; }
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
