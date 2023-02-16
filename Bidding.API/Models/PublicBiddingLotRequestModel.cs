using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
