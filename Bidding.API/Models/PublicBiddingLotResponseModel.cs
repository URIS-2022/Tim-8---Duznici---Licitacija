using System.Runtime.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "PublicBiddingLot", Namespace = "")]
    public class PublicBiddingLotResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Guid LotGuid { get; set; }


        [DataMember]
        public int LotNumber { get; set; }
    }
}
