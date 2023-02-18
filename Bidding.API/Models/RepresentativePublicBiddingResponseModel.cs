using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    [DataContract(Name = "RepresentativePublicBidding", Namespace = "")]
    public class RepresentativePublicBiddingResponseModel
    {

        [DataMember]

        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int StartPricePerHectar { get; set; }
        [DataMember]
        public string Expected { get; set; }
        [JsonConverter(typeof(MunicipalityConverter))]
        [DataMember(Name = "municipality")]
        public Municipality municipality { get; set; }
        [DataMember]
        public int AuctionedPrice { get; set; }
        [DataMember]
        public Guid BestBuyerGuid { get; set; }
        [JsonConverter(typeof(PublicBiddingTypeConverter))]
        [DataMember(Name = "public_bidding_type")]
        public PublicBiddingType public_bidding_type { get; set; }
        [DataMember]
        public Guid AddresGuid { get; set; }
        [DataMember]
        public int LeasePeriod { get; set; }
        [DataMember]
        public int DepositReplenishmentAmount { get; set; }
        [DataMember]

        public Guid Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]
        [DataMember(Name = "biddingStatus")]
        public BiddingStatus biddingStatus { get; set; }
    }
}
