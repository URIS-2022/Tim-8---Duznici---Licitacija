using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    /// <summary>
    /// Represents a repository for handling BuyerApplication entities.
    /// </summary>
    public class BuyerApplicationRepository : IBuyerApplicationRepository
    {
        private readonly BiddingDBContext _context;

        public BuyerApplicationRepository(BiddingDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all BuyerApplication entities from the database, including their representative.
        /// </summary>
        /// <returns>An IEnumerable of all BuyerApplication entities with their representative.</returns>

        public async Task<IEnumerable<BuyerApplication>> GetAllBuyerApplications()
        {
            return await _context.BuyerApplications.Include(c => c.representative).ToListAsync();
        }

        /// <summary>
        /// Gets a BuyerApplication entity from the database by its ID, including its representative.
        /// </summary>
        /// <param name="guid">The GUID of the BuyerApplication to retrieve.</param>

        public async Task<BuyerApplication> GetBuyerApplicationByGuid(Guid guid)
        {
            return await _context.BuyerApplications
                .Include(c => c.representative)
                .SingleOrDefaultAsync(x => x.Guid == guid);
        }

        /// <summary>
        /// Gets a BuyerApplication entity from the database by its amount, including its representative.
        /// </summary>
        /// <param name="amount">The amount of the BuyerApplication to retrieve.</param>

        public async Task<BuyerApplication?> GetBuyerApplicationByAmount(int amount)
        {
            return await _context.BuyerApplications.Include(c => c.representative).FirstOrDefaultAsync(ba => ba.Amount == amount);
        }

        /// <summary>
        /// Adds a new BuyerApplication entity to the database.
        /// </summary>
        /// <param name="buyerApplication">The BuyerApplication entity to add.</param>

        public async Task<BuyerApplication> AddBuyerApplication(BuyerApplication buyerApplication)
        {
            _context.BuyerApplications.Add(buyerApplication);
            await _context.SaveChangesAsync();
            return buyerApplication;
        }

        /// <summary>
        /// Deletes a BuyerApplication entity from the database by its ID.
        /// </summary>
        /// <param name="guid">The ID of the BuyerApplication entity to delete.</param>

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

        /// <summary>
        /// Updates an existing BuyerApplication entity in the database.
        /// </summary>
        /// <param name="buyerApplication">The updated BuyerApplication entity.</param>

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

