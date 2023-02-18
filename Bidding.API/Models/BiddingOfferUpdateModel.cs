/// <summary>
/// Represents a request to update an existing bidding offer.
/// </summary>

namespace Bidding.API.Models
{
    public class BiddingOfferUpdateModel
    {
       
        public Guid RepresentativeGuid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public DateTime? Date { get; set; }
        public float? Offer { get; set; }

        public Guid BuyerGuid { get; set; }

        public BiddingOfferUpdateModel() { }

        public BiddingOfferUpdateModel( Guid representativeGuid, Guid publicBiddingGuid, DateTime? date, float? offer, Guid buyerGuid)
        {
            
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
