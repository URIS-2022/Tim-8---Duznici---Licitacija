using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Bidding.API.Entities
{
    public partial class BiddingOffer : IValidatableObject
    {
        
        public Guid BiddingOfferGuid { get; set; }
        public Representative RepresentativeGuid { get; set; }
        public PublicBidding PublicBiddingGuid { get; set; }
        public DateOnly Date { get; set; }
        public float Offer { get; set; }

        public Guid BuyerGuid { get; set; }

        public BiddingOffer(Guid biddingOfferGuid, Representative representativeGuid, PublicBidding publicBiddingGuid, DateOnly date, float offer, Guid buyerGuid)
        {
            BiddingOfferGuid = biddingOfferGuid;
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }

        public BiddingOffer(Representative representativeGuid, PublicBidding publicBiddingGuid, DateOnly date, float offer, Guid buyerGuid)
        {
            BiddingOfferGuid = Guid.NewGuid();
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (BiddingOfferGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }
            if (BuyerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (RepresentativeGuid == null)
            {
                results.Add(new ValidationResult("Representative cannot be null."));
            }

            if (PublicBiddingGuid == null)
                results.Add(new ValidationResult("Public bidding cannot be null."));

            if (Offer <= 0)
            {
                results.Add(new ValidationResult("Offer must be greater than 0."));
            }

            if (Date == null)
            {
                results.Add(new ValidationResult("Date submissed cannot be null."));
            }
            return results;


        }
    }
}
