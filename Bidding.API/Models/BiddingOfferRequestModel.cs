namespace Bidding.API.Models
{
    public class BiddingOfferRequestModel
    {

        public Guid RepresentativeGuid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public DateTime Date { get; set; }
        public float Offer { get; set; }

        public Guid BuyerGuid { get; set; }

        public BiddingOfferRequestModel() { }

        public BiddingOfferRequestModel(Guid representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {

            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
