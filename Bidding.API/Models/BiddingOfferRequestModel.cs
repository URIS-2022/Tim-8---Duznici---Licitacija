namespace Bidding.API.Models
{

    /// <summary>
    /// Represents a model for a bidding offer request.
    /// </summary>
    public class BiddingOfferRequestModel
    {

        public Guid RepresentativeGuid { get; set; }
        /// <summary>
        /// Gets or sets the GUID of the public bidding to make the offer for.
        /// </summary>

        public Guid PublicBiddingGuid { get; set; }

        /// <summary>
        /// Gets or sets the date of the offer.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the offer amount.
        /// </summary>
        public float Offer { get; set; }

        /// <summary>
        /// Gets or sets the GUID of the buyer making the offer.
        /// </summary>

        public Guid BuyerGuid { get; set; }

        /// <summary>
        /// Initializes a new instance of the BiddingOfferRequestModel class.
        /// </summary>

        public BiddingOfferRequestModel() { }

        /// <summary>
        /// Initializes a new instance of the BiddingOfferRequestModel class with the specified values.
        /// </summary>
        /// <param name="representativeGuid">The GUID of the representative making the offer.</param>
        /// <param name="publicBiddingGuid">The GUID of the public bidding to make the offer for.</param>
        /// <param name="date">The date of the offer.</param>
        /// <param name="offer">The offer amount.</param>
        /// <param name="buyerGuid">The GUID of the buyer making the offer.</param>

        public BiddingOfferRequestModel(Guid representativeGuid, Guid publicBiddingGuid, DateTime date, float offer, Guid buyerGuid)
        {

            RepresentativeGuid = representativeGuid;
            PublicBiddingGuid = publicBiddingGuid;
            Date = date;
            Offer = offer;
            BuyerGuid = buyerGuid;
        }
    }
}
