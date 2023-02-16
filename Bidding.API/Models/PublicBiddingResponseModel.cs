using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    [DataContract(Name = "PublicBidding", Namespace = "")]
    public class PublicBiddingResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
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
        [DataMember(Name ="municipality")]
        public Municipality municipality { get; set; }
        [DataMember]
        public int AuctionedPrice { get; set; }
        [DataMember]
        public Guid BestBuyerGuid { get; set; }
        [JsonConverter(typeof(PublicBiddingTypeConverter))]
        [DataMember(Name = "public_bidding_type")]
        public PublicBiddingType public_bidding_type { get; set; }
        [DataMember]
        public AdressResponseModel Addres { get; set; }
        [DataMember]
        public int LeasePeriod { get; set; }
        [DataMember]
        public int DepositReplenishmentAmount { get; set; }
        [DataMember]

        public Guid Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]
        [DataMember(Name ="biddingStatus")]
        public BiddingStatus biddingStatus { get; set; }
        [DataMember] // mozda ne treba za ovu listu ispod
        public IEnumerable<PublicBiddingLotResponseModel> PublicBiddingLots { get; set; }

        public PublicBiddingResponseModel() { }

        public PublicBiddingResponseModel(
       
       DateTime date,
       DateTime startDate,
       DateTime endDate,
       int startPricePerHectar,
       string expected,
       Municipality municipality,
       int auctionedPrice,
       Guid bestBuyerGuid,
       PublicBiddingType public_bidding_type,
       AdressResponseModel address,
       int leasePeriod,
       int depositReplenishmentAmount,
       Guid round,
       BiddingStatus biddingStatus,
       IEnumerable<PublicBiddingLotResponseModel> publicBiddingLot
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
            Addres = address;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
            PublicBiddingLots = publicBiddingLot;
        }
    }
}
