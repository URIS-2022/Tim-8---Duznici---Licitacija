namespace Bidding.API.Models
{
    public class PublicBiddingLotUpdateModel
    {
        public Guid LotGuid { get; set; }
        public Guid PublicBiddingGuid { get; set; }
        public int? LotNumber { get; set; }

        public PublicBiddingLotUpdateModel() { }

        public PublicBiddingLotUpdateModel(Guid lotGuid, Guid publicBidding, int? lotNumber)
        {
            LotGuid = lotGuid;
            PublicBiddingGuid = publicBidding;
            LotNumber = lotNumber;
        }
    }
}
