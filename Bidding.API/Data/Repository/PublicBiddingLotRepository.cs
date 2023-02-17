using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class PublicBiddingLotRepository : IPublicBiddingLotRepository
    {
        private readonly BiddingDBContext context;

        public PublicBiddingLotRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        

        public async Task<IEnumerable<PublicBiddingLot>> GetAllBiddingLots()
        {
            return await context.PublicBiddingLots.ToListAsync();
        }

        public async Task<PublicBiddingLot> AddBiddingLot(PublicBiddingLot publicBiddingLot)
        {
            context.PublicBiddingLots.Add(publicBiddingLot);
            await context.SaveChangesAsync();
            return publicBiddingLot;
        }

        public async Task DeleteBiddingLot(Guid guid)
        {
            var publicBiddingLot = await context.PublicBiddingLots.FindAsync(guid);
            if (publicBiddingLot == null)
            {
                throw new InvalidOperationException("PublicBiddingLot not found");
            }
            context.PublicBiddingLots.Remove(publicBiddingLot);
            await context.SaveChangesAsync();
        }

        public async Task<PublicBiddingLot> GetPublicBiddingLotByGuid(Guid guid)
        {
            return await context.PublicBiddingLots.FindAsync(guid);
        }

        public async Task<PublicBiddingLot?> UpdateBiddingLot(PublicBiddingLot publicBiddingLot)
        {
            var existingPublicBiddingLot = await GetPublicBiddingLotByGuid(publicBiddingLot.Guid);
            if (existingPublicBiddingLot == null)
            {
                throw new InvalidOperationException($"The public bidding lot with ID '{publicBiddingLot.Guid}' was not found.");
            }

            context.Entry(existingPublicBiddingLot).CurrentValues.SetValues(publicBiddingLot);
            await context.SaveChangesAsync();

            return existingPublicBiddingLot;
        }
    }
}

