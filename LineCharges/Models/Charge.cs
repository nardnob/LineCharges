using System;
using System.ComponentModel.DataAnnotations;

namespace LineCharges.Models
{
    public class Charge
    {
        public Charge()
        {
        }

        public Charge(DateTime transactionDate)
        {
            TransactionDate = transactionDate;
        }

        /// <summary>
        /// Gets or sets the string value for the amount.
        /// </summary>
        [Required(ErrorMessage = "Charge Amount is required.")]
        [RegularExpression("-?[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage = "Charge Amount must be a valid number (up to two decimal places).")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the numeric value for the amount.
        /// </summary>
        public double AmountValue { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [Required(ErrorMessage = "Charge Type is required.")]
        public ChargeType? Type { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// The available charge types.
        /// </summary>
        public enum ChargeType
        {
            Deposit,
            Fee,
            Expense
        }

        /// <summary>
        /// Calculates and stores the numeric amount from the string amount.
        /// </summary>
        public void CalculateAmount()
        {
            AmountValue = Double.Parse(Amount);
        }
    }
}