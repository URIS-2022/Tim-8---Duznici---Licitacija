using System.Runtime.Serialization;


namespace Bidding.API.Models
{

    [DataContract(Name = "BiddingOffer", Namespace = "")]
    public class BiddingOfferResponseModel
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Guid RepresentativeGuid { get; set; }

        [DataMember]
        public Guid PublicBiddingGuid { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public float Offer { get; set; }

        [DataMember]
        public Guid BuyerGuid { get; set; }

        public BiddingOfferResponseModel() { }

        public BiddingOfferResponseModel(Guid representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {

            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
