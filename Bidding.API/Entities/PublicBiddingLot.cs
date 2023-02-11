using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Bidding.API.Entities
{
    public partial class PublicBiddingLot : IValidatableObject
    {
        public Guid Guid { get; set; }
        public Guid LotGuid { get; set; }
        public Guid PublicBidding { get; set; }
        public int LotNumber { get; set; }

        public PublicBiddingLot() { }

        public PublicBiddingLot(Guid publicBiddingLotGuid, Guid lotGuid, Guid publicBidding, int lotNumber)
        {
            Guid = publicBiddingLotGuid;
            LotGuid = lotGuid;
            PublicBidding = publicBidding;
            LotNumber = lotNumber;
        }

        public PublicBiddingLot( Guid lotGuid, Guid publicBidding, int lotNumber)
        {
            Guid =Guid.NewGuid();
            LotGuid = lotGuid;
            PublicBidding = publicBidding;
            LotNumber = lotNumber;
        }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (LotNumber <= 0)
            {
                errors.Add(new ValidationResult("Lot number must be greater than 0."));
            }
            if (Guid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Public bidding lot GUID cannot be empty."));
            }
            if (LotGuid == Guid.Empty)
            {
                errors.Add(new ValidationResult("Lot GUID cannot be empty."));
            }
            if (PublicBidding == Guid.Empty)
            {
                errors.Add(new ValidationResult("Public bidding GUID cannot be empty."));
            }
            return errors;
        }
    }
}
