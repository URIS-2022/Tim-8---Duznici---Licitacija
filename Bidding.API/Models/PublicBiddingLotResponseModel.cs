using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "PublicBiddingLot", Namespace = "")]
    public class PublicBiddingLotResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Guid LotGuid { get; set; }
        // public Guid PublicBiddingGuid { get; set; }

        [DataMember]
        public int LotNumber { get; set; }
    }
}
