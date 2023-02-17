using Bidding.API.Entities;

namespace Bidding.API.Data.Repository
{
    public interface IBuyerApplicationRepository
    {
        Task<IEnumerable<BuyerApplication>> GetAllBuyerApplications();
        Task<BuyerApplication> GetBuyerApplicationByGuid(Guid guid);
        Task<BuyerApplication?> GetBuyerApplicationByAmount(int amount);
        Task<BuyerApplication> AddBuyerApplication(BuyerApplication buyerApplication);
        Task DeleteBuyerApplication(Guid guid);
        Task<BuyerApplication?> UpdateBuyerApplication(BuyerApplication buyerApplication);
    }
}
