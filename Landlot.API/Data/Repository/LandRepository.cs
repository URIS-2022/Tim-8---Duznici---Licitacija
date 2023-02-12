using Landlot.API.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Landlot.API.Entities;

namespace Landlot.API.Data.Repository
{
    public class LandRepository : ILandRepository
    {
        private readonly LandlotDbContext context;

        public LandRepository(LandlotDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Land>> GetLands()
        {
            return await context.Lands.ToListAsync();
        }

        public async Task<Land?> GetLand(Guid id)
        {
            return await context.Lands.FindAsync(id);
        }

        public async Task<Land?> UpdateLand(Guid id,Land updateModel)
        {
            var land = await context.Lands.FirstOrDefaultAsync(c => c.LandGuid == id);
            if (land == null)
            {
                return null;
            }
            context.Entry(land).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return land;
        }

        public async Task<Land?> AddLand(Land land)
        {
            var created = context.Lands.Add(land);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task DeleteLand(Guid id)
        {
            var systemUser = await context.Lands.FindAsync(id);
            if (systemUser == null)
            {
                throw new InvalidOperationException("Land not found");
            }
            context.Lands.Remove(systemUser);
            await context.SaveChangesAsync();
        }

    }
}