using System.Runtime.Serialization;


namespace Bidding.API.Models
{
    /// <summary>
    /// Represents a bidding offer in the system.
    /// </summary>

    [DataContract(Name = "BiddingOffer", Namespace = "")]
    public class BiddingOfferResponseModel
    {

        /// <summary>
        /// Gets or sets the unique identifier of the bidding offer.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the representative making the offer.
        /// </summary>

        [DataMember]
        public Guid RepresentativeGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the public bidding the offer is made for.
        /// </summary>

        [DataMember]
        public Guid PublicBiddingGuid { get; set; }

        /// <summary>
        /// Gets or sets the date when the offer was made.
        /// </summary>

        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the value of the offer.
        /// </summary>

        [DataMember]
        public float Offer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the buyer associated with the bidding offer.
        /// </summary>

        [DataMember]
        public Guid BuyerGuid { get; set; }

        /// <summary>
        /// Initializes a new instance of the BiddingOfferResponseModel class.
        /// </summary>

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
