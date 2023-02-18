using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{

    /// <summary>
    /// Represents a repository for managing BiddingOffers in the database.
    /// </summary>
    public class BiddingOfferRepository : IBiddingOfferRepository
    {
        private readonly BiddingDBContext context;

        public BiddingOfferRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all BiddingOffers from the database.
        /// </summary>
        /// <returns>An enumerable collection of all BiddingOffers.</returns>

        public async Task<IEnumerable<BiddingOffer>> GetAllBiddingOffers()
        {
            return await context.BiddingOffers.ToListAsync();
        }

        /// <summary>
        /// Gets a BiddingOffer by its GUID.
        /// </summary>
        /// <param name="guid">The GUID of the BiddingOffer to retrieve.</param>
        /// <returns>The BiddingOffer with the specified GUID, or null if not found.</returns>
        public async Task<BiddingOffer> GetBiddingOfferByGuid(Guid guid)
        {
            return await context.BiddingOffers.FindAsync(guid);
        }

        /// <summary>
        /// Gets a BiddingOffer by its offer value.
        /// </summary>
        /// <param name="offer">The offer value of the BiddingOffer to retrieve.</param>
        /// <returns>The BiddingOffer with the specified offer value, or null if not found.</returns>

        public async Task<BiddingOffer?> GetBiddingOfferByOffer(float offer)
        {
            return await context.BiddingOffers.FirstOrDefaultAsync(x => x.Offer == offer);
        }

        /// <summary>
        /// Adds a new BiddingOffer to the database.
        /// </summary>
        /// <param name="biddingOffer">The BiddingOffer to add.</param>
        /// <returns>The added BiddingOffer.</returns>
        public async Task<BiddingOffer> AddBiddingOffer(BiddingOffer biddingOffer)
        {
            context.BiddingOffers.Add(biddingOffer);
            await context.SaveChangesAsync();
            return biddingOffer;
        }

        /// <summary>
        /// Deletes a BiddingOffer from the database.
        /// </summary>
        /// <param name="guid">The GUID of the BiddingOffer to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        public async Task DeleteBiddingOffer(Guid guid)
        {
            var biddingOffer = await context.BiddingOffers.FindAsync(guid);
            if (biddingOffer == null)
            {
                throw new InvalidOperationException("BiddingOffer not found");
            }
            context.BiddingOffers.Remove(biddingOffer);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a BiddingOffer in the database.
        /// </summary>
        /// <param name="biddingOffer">The updated BiddingOffer.</param>
        /// <returns>The updated BiddingOffer, or null if it does not exist in the database.</returns>

        public async Task<BiddingOffer?> UpdateBiddingOffer(BiddingOffer biddingOffer)
        {
            var existingBiddingOffer = await context.BiddingOffers.FindAsync(biddingOffer.Guid);
            if (existingBiddingOffer == null)
            {
                throw new InvalidOperationException($"The BiddingOffer with ID '{biddingOffer.Guid}' was not found.");
            }

            context.Entry(existingBiddingOffer).CurrentValues.SetValues(biddingOffer);
            await context.SaveChangesAsync();

            return existingBiddingOffer;
        }
    }
}
