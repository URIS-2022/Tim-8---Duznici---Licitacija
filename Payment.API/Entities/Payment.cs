using System.ComponentModel.DataAnnotations;

namespace Payment.API.Entities
{
    /// <summary>
    /// Represents a payment warrant entity.
    /// </summary>
    public class Payment : IValidatableObject
    {

        /// <summary>
        /// The unique identifier for the payment.
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// The account number for the payment.
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// The reference number for the payment.
        /// </summary>
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// The total amount for the payment.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The unique identifier of the payer.
        /// </summary>
        public Guid PayerGuid { get; set; }

        /// <summary>
        /// The title of the payment.
        /// </summary>
        public string? PaymentTitle { get; set; }

        /// <summary>
        /// The date of the payment.
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// The unique identifier of the public bidding.
        /// </summary>
        public Guid PublicBiddingGuid { get; set; }

        /// <summary>
        /// The payment warrant associated with the payment.
        /// </summary>
        public PaymentWarrant? PaymentWarrant { get; set; }

        /// <summary>
        /// Default constructor for Payment class.
        /// </summary>
        public Payment()
        {
        }

        /// <summary>
        /// Validates the Payment object using the specified context.
        /// </summary>
        /// <param name="validationContext">The context to use for validation.</param>
        /// <returns>An enumerable collection of ValidationResult objects.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(AccountNumber))
            {
                results.Add(new ValidationResult("AccountNumber cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(ReferenceNumber))
            {
                results.Add(new ValidationResult("ReferenceNumber cannot be empty."));
            }

            if (TotalAmount <= 0)
            {
                results.Add(new ValidationResult("TotalAmount must be greater than 0."));
            }

            if (PayerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PayerGuid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(PaymentTitle))
            {
                results.Add(new ValidationResult("PaymentTitle cannot be empty."));
            }

            if (PaymentDate < DateTime.Now)
            {
                results.Add(new ValidationResult("Payment date cannot be in the past."));
            }

            if (PublicBiddingGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PublicBiddingGuid cannot be empty."));
            }

            return results;
        }
    }
    
}
