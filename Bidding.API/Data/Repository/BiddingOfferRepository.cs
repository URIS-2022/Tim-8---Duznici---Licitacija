using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class BiddingOfferRepository : IBiddingOfferRepository
    {
        private readonly BiddingDBContext context;

        public BiddingOfferRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BiddingOffer>> GetAllBiddingOffers()
        {
            return await context.BiddingOffers.ToListAsync();
        }

        public async Task<BiddingOffer> GetBiddingOfferByGuid(Guid guid)
        {
            return await context.BiddingOffers.FindAsync(guid);
        }

        public async Task<BiddingOffer?> GetBiddingOfferByOffer(float offer)
        {
            return await context.BiddingOffers.FirstOrDefaultAsync(x => x.Offer == offer);
        }

        public async Task<BiddingOffer> AddBiddingOffer(BiddingOffer biddingOffer)
        {
            context.BiddingOffers.Add(biddingOffer);
            await context.SaveChangesAsync();
            return biddingOffer;
        }

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
