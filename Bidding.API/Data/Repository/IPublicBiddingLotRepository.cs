using Bidding.API.Entities;

namespace Bidding.API.Data.Repository
{
    public interface IPublicBiddingLotRepository
    {
        public interface IPublicBiddingLotRepository
        {
            Task<IEnumerable<PublicBiddingLot>> GetAllBiddingLots();
             Task<PublicBiddingLot> GetPublicBiddingLotByGuid(Guid guid);
            // Task<Document?> GetDocumentByReferenceNumber(string referenceNumber);
            Task<PublicBiddingLot> AddBiddingLot(PublicBiddingLot publicBiddingLot);
            Task DeleteBiddingLot(Guid guid);
            Task<PublicBiddingLot?> UpdateBiddingLot(PublicBiddingLot publicBiddingLot);
        }
    }
}
