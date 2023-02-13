using System.ComponentModel.DataAnnotations;

namespace Payment.API.Entities
{
    public class PaymentWarrant : IValidatableObject
    {
        public Guid Guid { get; set; }
        public string ReferenceNumber { get; set; }
        public Guid PayerGuid { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public ICollection<PaymentEntity> payments { get; internal set; }

        public PaymentWarrant()
        {
        }

        public PaymentWarrant(Guid paymentWarrantGuid, string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
        {
            Guid = paymentWarrantGuid;
            ReferenceNumber = referenceNumber;
            PayerGuid = payerGuid;
            TotalAmount = totalAmount;
            PublicBiddingGuid = publicBiddingGuid;
        }

        public PaymentWarrant(string referenceNumber, Guid payerGuid, decimal totalAmount, Guid publicBiddingGuid)
        {
            Guid = Guid.NewGuid(); ;
            ReferenceNumber = referenceNumber;
            PayerGuid = payerGuid;
            TotalAmount = totalAmount;
            PublicBiddingGuid = publicBiddingGuid;
        }

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
