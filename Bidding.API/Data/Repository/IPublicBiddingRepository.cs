using Bidding.API.Entities;


namespace Bidding.API.Data.Repository
{
    public interface IPublicBiddingRepository
    {
        Task<IEnumerable<PublicBidding>> GetAllPublicBiddings();
        Task<PublicBidding> GetPublicBiddingByGuid(Guid guid);
        Task<PublicBidding?> GetPublicBiddingByAuctionedPrice(int auctionedPrice);
        Task<PublicBidding> AddPublicBidding(PublicBidding publicBidding);
        Task DeletePublicBidding(Guid guid);
        Task<PublicBidding?> UpdatePublicBidding(PublicBidding publicBidding);
    }
}
