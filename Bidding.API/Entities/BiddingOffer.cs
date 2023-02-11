using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Bidding.API.Entities
{
    public partial class BiddingOffer : IValidatableObject
    {
        
        public Guid Guid { get; set; }
        public Guid RepresentativeGuid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public DateTime Date { get; set; }
        public float Offer { get; set; }

        public Guid BuyerGuid { get; set; }

        public BiddingOffer() { }

        public BiddingOffer(Guid biddingOfferGuid, Guid representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {
            Guid = biddingOfferGuid;
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }

        public BiddingOffer(Guid representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {
            Guid = Guid.NewGuid();
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }
            if (BuyerGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (RepresentativeGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

            if (PublicBiddingGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }

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
