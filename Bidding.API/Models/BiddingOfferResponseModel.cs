using Bidding.API.Entities;
using Bidding.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{

    [DataContract(Name = "BiddingOffer", Namespace = "")]
    public class BiddingOfferResponseModel
    {
       

        [DataMember]
        public Representative RepresentativeGuid { get; set; }

        [DataMember]
        public Guid PublicBiddingGuid { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public float Offer { get; set; }

        [DataMember]
        public Guid BuyerGuid { get; set; }

        public BiddingOfferResponseModel( Representative representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {
            
            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
