using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    public class BiddingOfferUpdateModel
    {
        
        public Representative RepresentativeGuid { get; set; }
        public PublicBidding PublicBiddingGuid { get; set; }
        public DateTime? Date { get; set; }
        public float? Offer { get; set; }

        public Guid BuyerGuid { get; set; }

        public BiddingOfferUpdateModel( Representative representativeGuid, PublicBidding publicBiddingGuid, DateTime? date, float? offer, Guid buyerGuid)
        {
            
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
