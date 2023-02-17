namespace Bidding.API.Models
{
    public class PublicBiddingLotRequestModel
    {
        public Guid LotGuid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public int LotNumber { get; set; }

        public PublicBiddingLotRequestModel() { }

        public PublicBiddingLotRequestModel(Guid lotGuid, Guid publicBidding, int lotNumber)
        {
            LotGuid = lotGuid;
            PublicBiddingGuid = publicBidding;
            LotNumber = lotNumber;
        }
    }
}
