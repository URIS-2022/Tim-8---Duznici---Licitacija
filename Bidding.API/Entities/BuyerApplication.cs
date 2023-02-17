using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class BuyerApplication : IValidatableObject
    {
        public Guid Guid { get; set; }

        public Guid RepresentativeGuid { get; set; }

        public int Amount { get; set; }

        public Representative representative { get; set; }

        public BuyerApplication() { }

        public BuyerApplication(Guid buyerGuid, Guid representativeGuid, int amount)
        {
            Guid = buyerGuid;
            RepresentativeGuid = representativeGuid;
            Amount = amount;
        }

        public BuyerApplication(Guid representativeGuid, int amount)
        {
            Guid = Guid.NewGuid();
            RepresentativeGuid = representativeGuid;
            Amount = amount;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (Guid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Buyer GUID cannot be empty."));
            }
            if (RepresentativeGuid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Representative GUID cannot be empty."));
            }
            if (Amount <= 0)
            {
                errors.Add(new ValidationResult("Amount must be greater than 0."));
            }
            return errors;
        }
    }
}
