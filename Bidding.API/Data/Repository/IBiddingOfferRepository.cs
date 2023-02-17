using Bidding.API.Entities;

namespace Bidding.API.Data.Repository
{
    public interface IBiddingOfferRepository
    {
        Task<IEnumerable<BiddingOffer>> GetAllBiddingOffers();
        Task<BiddingOffer> GetBiddingOfferByGuid(Guid guid);
        Task<BiddingOffer?> GetBiddingOfferByOffer(float offer);
        Task<BiddingOffer> AddBiddingOffer(BiddingOffer biddingOffer);
        Task DeleteBiddingOffer(Guid guid);
        Task<BiddingOffer?> UpdateBiddingOffer(BiddingOffer biddingOffer);
    }
}
