using MoneyManager.Domain.Common;
using System;

namespace MoneyManager.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public AccountType Type { get; private set; }
        public AccountStatus Status { get; private set; }      
        public decimal InitialBalance { get; private set; }
        public bool IsFavorite { get; private set; }
        public Currency Currency { get; private set; }
        public string Notes { get; private set; }

        #region Others
        /// <summary>
        /// Account number
        /// </summary>
        public string Number { get; private set; }
        public string HeldAt { get; private set; }
        public string Website { get; private set; }
        public string ContactInfo { get; private set; }
        #endregion

        #region Statement
        /// <summary>
        /// Enable/disable transaction lock
        /// </summary>
        public bool StatementLocked { get; private set; } 
        /// <summary>
        /// Date of the transaction lock
        /// </summary>
        public DateTime StatementDate { get; private set; }
        /// <summary>
        /// Account balance lower limit. Zero to disable
        /// </summary>
        public decimal MinBalance { get; private set; }
        #endregion    

        #region Credit
        /// <summary>
        /// Zero to disable
        /// </summary>
        public decimal CreditLimit { get; private set; }
        public decimal InterestRate { get; private set; } //TODO What is it
        public DateTime PaymentDueDate { get; private set; } //TODO What is it
        public decimal MinPayment { get; private set; }
        #endregion
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
