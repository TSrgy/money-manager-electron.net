using MoneyManager.Domain.Common;
using System;

namespace MoneyManager.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; }      
        public decimal InitialBalance { get; set; }
        public bool IsFavorite { get; set; }
        public Currency Currency { get; set; }
        public string Notes { get; set; }

        #region Others
        /// <summary>
        /// Account number
        /// </summary>
        public string Number { get; set; }
        public string HeldAt { get; set; }
        public string Website { get; set; }
        public string ContactInfo { get; set; }
        #endregion

        #region Statement
        /// <summary>
        /// Enable/disable transaction lock
        /// </summary>
        public bool StatementLocked { get; set; } 
        /// <summary>
        /// Date of the transaction lock
        /// </summary>
        public DateTime StatementDate { get; set; }
        /// <summary>
        /// Account balance lower limit. Zero to disable
        /// </summary>
        public decimal MinBalance { get; set; }
        #endregion    

        #region Credit
        /// <summary>
        /// Zero to disable
        /// </summary>
        public decimal CreditLimit { get; set; }
        public decimal InterestRate { get; set; } //TODO What is it
        public DateTime PaymentDueDate { get; set; } //TODO What is it
        public decimal MinPayment { get; set; }
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
