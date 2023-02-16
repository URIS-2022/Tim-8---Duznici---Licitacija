
using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    [DataContract(Name = "PublicBiddingLot", Namespace = "")]
    public class PublicBiddingLotNewResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Guid lotGuid { get; set; }
        [DataMember]
        public Guid publicBiddingGuid { get; set; }
        [DataMember]
        public int LotNumber { get; set; }

        public PublicBiddingLotNewResponseModel() { }

        public PublicBiddingLotNewResponseModel(Guid guid,Guid lotGuid, Guid publicBidding, int lotNumber)
        {
            Guid = guid;
            this.lotGuid = lotGuid;
            publicBiddingGuid = publicBidding;
            LotNumber = lotNumber;
        }
    }
}
