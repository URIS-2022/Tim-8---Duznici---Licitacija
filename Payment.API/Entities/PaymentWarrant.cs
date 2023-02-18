using System.ComponentModel.DataAnnotations;

namespace Payment.API.Entities
{
    /// <summary>
    /// Represents a payment warrant entity.
    /// </summary>
    public class PaymentWarrant : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for the payment warrant.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the reference number for the payment warrant.
        /// </summary>
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the payer.
        /// </summary>
        public Guid PayerGuid { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the payment warrant.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the public bidding.
        /// </summary>
        public Guid PublicBiddingGuid { get; set; }

        /// <summary>
        /// Gets or sets the list of payments associated with this payment warrant.
        /// </summary>
        public ICollection<Payment>? Payments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarrant"/> class.
        /// </summary>
        public PaymentWarrant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarrant"/> class with specified parameters.
        /// </summary>
        /// <param name="paymentWarrantGuid">The unique identifier for the payment warrant.</param>
        /// <param name="referenceNumber">The reference number for the payment warrant.</param>
        /// <param name="payerGuid">The unique identifier of the payer.</param>
        /// <param name="totalAmount">The total amount for the payment warrant.</param>
        /// <param name="publicBiddingGuid">The unique identifier of the public bidding.</param>

        public PaymentWarrant(Guid paymentWarrantGuid, string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
        {
            Guid = paymentWarrantGuid;
            ReferenceNumber = referenceNumber;
            PayerGuid = payerGuid;
            TotalAmount = totalAmount;
            PublicBiddingGuid = publicBiddingGuid;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarrant"/> class with specified parameters.
        /// </summary>
        /// <param name="referenceNumber">The reference number for the payment warrant.</param>
        /// <param name="payerGuid">The unique identifier of the payer.</param>
        /// <param name="totalAmount">The total amount for the payment warrant.</param>
        /// <param name="publicBiddingGuid">The unique identifier of the public bidding.</param>
        public PaymentWarrant(string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
        {
            Guid = Guid.NewGuid();
            ReferenceNumber = referenceNumber;
            PayerGuid = payerGuid;
            TotalAmount = totalAmount;
            PublicBiddingGuid = publicBiddingGuid;
        }


        /// <summary>
        /// Constructor for creating a new PaymentWarrant object with a specified paymentWarrantGuid, payerGuid, totalAmount, and publicBiddingGuid.
        /// </summary>
        /// <param name="paymentWarrantGuid">The GUID of the payment warrant.</param>
        /// <param name="payerGuid">The GUID of the payer.</param>
        /// <param name="totalAmount">The total amount of the payment.</param>
        /// <param name="publicBiddingGuid">The GUID of the public bidding.</param>
        public PaymentWarrant(Guid paymentWarrantGuid, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
        {
            Guid = paymentWarrantGuid;
            PayerGuid = payerGuid;
            TotalAmount = totalAmount;
            PublicBiddingGuid = publicBiddingGuid;
        }


        /// <summary>
        /// Validates the PaymentWarrant object.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>An IEnumerable of ValidationResult objects.</returns>

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("PaymentWarrantGuid cannot be empty."));
            }

            if (string.IsNullOrWhiteSpace(ReferenceNumber))
            {
                results.Add(new ValidationResult("ReferenceNumber cannot be empty."));
            }

            if (PayerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PayerGuid cannot be empty."));
            }

            if (TotalAmount <= 0)
            {
                results.Add(new ValidationResult("TotalAmount must be greater than 0."));
            }

            if (PublicBiddingGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("PublicBiddingGuid cannot be empty."));
            }

            return results;
        }
    }
}
