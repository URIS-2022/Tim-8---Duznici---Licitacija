using Landlot.API.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Landlot.API.Entities;

namespace Landlot.API.Data.Repository
{
    public class LotRepository : ILotRepository
    {
        private readonly LandlotDbContext context;

        public LotRepository(LandlotDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Lot>> GetLots()
        {
            return await context.Lots.ToListAsync();
        }

        public async Task<Lot?> GetLot(Guid id)
        {
            return await context.Lots.FindAsync(id);
        }

        public async Task<Lot?> UpdateLot(Guid id, Lot updateModel)
        {
            var lot = await context.Lots.FirstOrDefaultAsync(c => c.LotGuid == id);
            if (lot == null)
            {
                return null;
            }
            context.Entry(lot).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return lot;
        }

        public async Task<Lot?> AddLot(Lot lot)
        {
            var created = context.Lots.Add(lot);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task DeleteLot(Guid id)
        {
            var systemUser = await context.Lots.FindAsync(id);
            if (systemUser == null)
            {
                throw new InvalidOperationException("Lot not found");
            }
            context.Lots.Remove(systemUser);
            await context.SaveChangesAsync();
        }
    }
}
