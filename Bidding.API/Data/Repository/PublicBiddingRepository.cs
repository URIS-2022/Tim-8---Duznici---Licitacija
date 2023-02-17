using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class PublicBiddingRepository : IPublicBiddingRepository
    {
        private readonly BiddingDBContext context;

        public PublicBiddingRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        public async Task<PublicBidding> AddPublicBidding(PublicBidding publicBidding)
        {
            context.PublicBiddings.Add(publicBidding);
           
            await context.SaveChangesAsync();
            return publicBidding;
        }

        public async Task DeletePublicBidding(Guid guid)
        {
            var publicBidding = await context.PublicBiddings.FindAsync(guid);
            if (publicBidding == null)
            {
                throw new InvalidOperationException("PublicBidding not found");
            }
            context.PublicBiddings.Remove(publicBidding);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PublicBidding>> GetAllPublicBiddings()
        {
            return await context.PublicBiddings
                .Include(c => c.Address)
                .Include(c => c.PublicBiddingLots)
                .ToListAsync();
        }

        public async Task<PublicBidding?> GetPublicBiddingByAuctionedPrice(int auctionedPrice)
        {
            var publicBidding = await context.PublicBiddings
                .Include(c => c.Address)
                .Include(c => c.PublicBiddingLots)
                .SingleOrDefaultAsync(x => x.AuctionedPrice == auctionedPrice);

            return publicBidding;
        }

        public async Task<PublicBidding> GetPublicBiddingByGuid(Guid guid)
        {
            var publicBidding = await context.PublicBiddings
                .Include(c => c.Address)
                .Include(c => c.PublicBiddingLots)
                .SingleOrDefaultAsync(x => x.Guid == guid);

            return publicBidding;
        }

        public async Task<PublicBidding?> UpdatePublicBidding(PublicBidding publicBidding)
        {
            var existingPublicBidding = await context.PublicBiddings.SingleOrDefaultAsync(x => x.Guid == publicBidding.Guid); // ako ne bude radilo izbaciti address,ovdje je bilo Async
            if (existingPublicBidding == null)
            {
                throw new InvalidOperationException($"The PublicBidding with ID '{publicBidding.Guid}' was not found.");
            }

            context.Entry(existingPublicBidding).CurrentValues.SetValues(publicBidding);
            await context.SaveChangesAsync();

            return existingPublicBidding;
        }
    }
}
