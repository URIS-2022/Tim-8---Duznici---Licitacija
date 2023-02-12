using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class BuyerApplicationRepository : IBuyerApplicationRepository
    {
        private readonly BiddingDBContext _context;

        public BuyerApplicationRepository(BiddingDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuyerApplication>> GetAllBuyerApplications()
        {
            return await _context.BuyerApplications.ToListAsync();
        }

        public async Task<BuyerApplication> GetBuyerApplicationByGuid(Guid guid)
        {
            return await _context.BuyerApplications.FindAsync(guid);
        }

        public async Task<BuyerApplication?> GetBuyerApplicationByAmount(int amount)
        {
            return await _context.BuyerApplications.FirstOrDefaultAsync(ba => ba.Amount == amount);
        }

        public async Task<BuyerApplication> AddBuyerApplication(BuyerApplication buyerApplication)
        {
            _context.BuyerApplications.Add(buyerApplication);
            await _context.SaveChangesAsync();
            return buyerApplication;
        }

        public async Task DeleteBuyerApplication(Guid guid)
        {
            var buyerApplication = await GetBuyerApplicationByGuid(guid);
            if (buyerApplication == null)
            {
                throw new InvalidOperationException($"The buyer application with ID '{guid}' was not found.");
            }

            _context.BuyerApplications.Remove(buyerApplication);
            await _context.SaveChangesAsync();
        }

        public async Task<BuyerApplication?> UpdateBuyerApplication(BuyerApplication buyerApplication)
        {
            var existingBuyerApplication = await GetBuyerApplicationByGuid(buyerApplication.Guid);
            if (existingBuyerApplication == null)
            {
                throw new InvalidOperationException($"The buyer application with ID '{buyerApplication.Guid}' was not found.");
            }

            _context.Entry(existingBuyerApplication).CurrentValues.SetValues(buyerApplication);
            await _context.SaveChangesAsync();

            return existingBuyerApplication;
        }
    }
}

