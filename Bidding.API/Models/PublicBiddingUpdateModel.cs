using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Bidding.API.Models
{
    [DataContract(IsReference = true)]
    public class PublicBiddingUpdateModel
    {


        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
        [DataMember]
        public int? StartPricePerHectar { get; set; }
        [DataMember]
        public string? Expected { get; set; }
        [JsonConverter(typeof(MunicipalityConverter))]
        [DataMember]
        public Municipality? municipality { get; set; }
        [DataMember]
        public int? AuctionedPrice { get; set; }
        [DataMember]
        public Guid? BestBuyerGuid { get; set; }
        [JsonConverter(typeof(PublicBiddingTypeConverter))]
        [DataMember]
        public PublicBiddingType? public_bidding_type { get; set; }
        [DataMember]
        public Guid? AddressGuid { get; set; }
        [DataMember]
        public int? LeasePeriod { get; set; }
        [DataMember]
        public int? DepositReplenishmentAmount { get; set; }

        [DataMember]
        public Guid? Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]
        [DataMember]
        public BiddingStatus? biddingStatus { get; set; }
    
        public PublicBiddingUpdateModel() { }
        
        public PublicBiddingUpdateModel(
       
       DateTime? date,
       DateTime? startDate,
       DateTime? endDate,
       int? startPricePerHectar,
       string? expected,
       Municipality? municipality,
       int? auctionedPrice,
       Guid? bestBuyerGuid,
       PublicBiddingType? public_bidding_type,
       Guid? addressGuid,
       int? leasePeriod,
       int? depositReplenishmentAmount,
       Guid? round,
       BiddingStatus? biddingStatus
       

        )
        {
            
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            AddressGuid = addressGuid;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
            
        }
        
    }
}
