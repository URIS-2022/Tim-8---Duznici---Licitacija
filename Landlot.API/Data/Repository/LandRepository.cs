using Landlot.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Landlot.API.Data.Repository
{
    /// <summary>
    /// Implements the ILandRepository interface to provide CRUD operations for land records.
    /// </summary>
    public class LandRepository : ILandRepository
    {
        private readonly LandlotDbContext context;
        /// <summary>
        /// Initializes a new instance of the LandRepository class with the specified database context.
        /// </summary>
        /// <param name="context">The database context for the repository.</param>
        public LandRepository(LandlotDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Gets all land records asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of all land records in the database.
        /// </returns>
        public async Task<IEnumerable<Land>> GetLands()
        {
            return await context.Lands.ToListAsync();
        }
        /// <summary>
        /// Gets the land record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the land record to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the land record with the specified ID, or null if no such record exists.
        /// </returns>
        public async Task<Land?> GetLand(Guid id)
        {
            return await context.Lands.FindAsync(id);
        }
        /// <summary>
        /// Updates the land record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the land record to update.</param>
        /// <param name="updateModel">The updated land record information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the updated land record, or null if no such record exists.
        /// </returns>
        public async Task<Land?> UpdateLand(Guid id, Land updateModel)
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
        /// <summary>
        /// Adds a new land record to the database asynchronously.
        /// </summary>
        /// <param name="land">The land record to add to the database.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the added land record, including any database-generated fields.
        /// </returns>
        public async Task<Land?> AddLand(Land land)
        {
            var created = context.Lands.Add(land);
            await context.SaveChangesAsync();
            return created.Entity;
        }
        /// <summary>
        /// Deletes the land record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the land record to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
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