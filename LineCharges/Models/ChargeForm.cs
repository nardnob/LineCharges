using System;
using System.Collections.Generic;

namespace LineCharges.Models
{
    public class ChargeForm
    {
        public ChargeForm()
        {
            ChargeEntry = new Charge();
            Charges = new List<Charge>();
            TotalDeposits = 0;
            TotalExpenses = 0;
            TotalFees = 0;
        }

        public ChargeForm(ChargeForm chargeForm) : base()
        {
            TotalDeposits = chargeForm.TotalDeposits;
            TotalExpenses = chargeForm.TotalExpenses;
            TotalFees = chargeForm.TotalFees;
            Charges = chargeForm.Charges;
        }

        /// <summary>
        /// Gets or sets the charge entry.
        /// </summary>
        public Charge ChargeEntry { get; set; }

        /// <summary>
        /// Gets or sets the charges.
        /// </summary>
        public List<Charge> Charges { get; set; }

        /// <summary>
        /// Gets or sets the total deposits.
        /// </summary>
        public double TotalDeposits { get; set; }

        /// <summary>
        /// Gets or sets the total expenses.
        /// </summary>
        public double TotalExpenses { get; set; }

        /// <summary>
        /// Gets or sets the total fees.
        /// </summary>
        public double TotalFees { get; set; }

        /// <summary>
        /// Adds the ChargeEntry to the existing Charges list.
        /// </summary>
        public void SaveEntry()
        {
            CalculateTotals();
            ChargeEntry.CalculateAmount();
            ChargeEntry.TransactionDate = DateTime.Now;
            Charges.Add(ChargeEntry);
        }

        /// <summary>
        /// Calculates the totals.
        /// </summary>
        public void CalculateTotals()
        {
            var amount = Double.Parse(ChargeEntry.Amount);

            switch (ChargeEntry.Type)
            {
                case Charge.ChargeType.Deposit:
                    TotalDeposits += amount;
                    break;
                case Charge.ChargeType.Expense:
                    TotalExpenses += amount;
                    break;
                case Charge.ChargeType.Fee:
                    TotalFees += amount;
                    break;
                default:
                    throw new Exception("Unhandled charge type");
            }
        }
    }
}