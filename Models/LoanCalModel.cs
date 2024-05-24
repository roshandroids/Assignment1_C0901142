using System.ComponentModel; // Importing the namespace for component model attributes
using System.ComponentModel.DataAnnotations; // Importing the namespace for data annotations
using System.Runtime.ConstrainedExecution; // Importing the namespace for constrained execution

namespace Assignment1_C0901142.Models
{
 
    /// Model representing the loan payment calculation.
    
    public class LoanCalModel
    {
        /// <summary>
        /// Gets or sets the principal amount of the loan.
        
        [Required(ErrorMessage = "Please enter value for principal amount.")]
        [Range(200, 2000, ErrorMessage = "The principal must be between 200 and 2000.")]
        public int? Principal { get; set; }

        /// <summary>
        /// Gets or sets the yearly interest rate of the loan.
        
        [Required(ErrorMessage = "Please enter value for interest rate.")]
        [Range(1, 100, ErrorMessage = "The interest rate must be between 1 and 100.")]
        public int? YearlyInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the number of payments per year.
        
        [Required(ErrorMessage = "Please enter value for number of payments per year.")]
        [Range(1, 12, ErrorMessage = "The number of payments per year must be between 1 and 12.")]
        public int? NumberOfPaymentsPerYear { get; set; }

        /// <summary>
        /// Calculates the loan payment per period.
        
        /// <returns>The calculated loan payment per period as a decimal.</returns>
        public decimal CalculateLoanPaymentPerPeriod()
        {
            /*
             * Calculation formula:
             * loan payment per period = principal * interest rate / (100 * number of payments per year)
             */
            if (Principal.HasValue && YearlyInterestRate.HasValue && NumberOfPaymentsPerYear.HasValue)
            {
                decimal PaymentPerPeriod = (decimal)(Principal * YearlyInterestRate / (100.0m * NumberOfPaymentsPerYear));
                return PaymentPerPeriod; // Returning the calculated payment per period
            }
            else
            {
                throw new InvalidOperationException("Invalid input values for calculation.");
            }
        }
    }
}
