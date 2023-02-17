using Microsoft.EntityFrameworkCore;
using Landlot.API.Entities;

namespace Landlot.API.Data.Repository
{
    /// <summary>
    /// Implements the ILotRepository interface to provide CRUD operations for land records.
    /// </summary>
    public class LotRepository : ILotRepository
    {
        private readonly LandlotDbContext context;
        /// <summary>
        /// Initializes a new instance of the LotRepository class with the specified database context.
        /// </summary>
        /// <param name="context">The database context for the repository.</param>
        public LotRepository(LandlotDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Gets all lot records asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of all lot records in the database.
        /// </returns>
        public async Task<IEnumerable<Lot>> GetLots()
        {
            return await context.Lots.ToListAsync();
        }
        /// <summary>
        /// Gets the lot record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the lot record to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the lot record with the specified ID, or null if no such record exists.
        /// </returns>
        public async Task<Lot?> GetLot(Guid id)
        {
            return await context.Lots.FindAsync(id);
        }
        /// <summary>
        /// Updates the lot record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the lot record to update.</param>
        /// <param name="updateModel">The updated lot record information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the updated lot record, or null if no such record exists.
        /// </returns>
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
        /// <summary>
        /// Adds a new lot record to the database asynchronously.
        /// </summary>
        /// <param name="lot">The lot record to add to the database.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the added lot record, including any database-generated fields.
        /// </returns>
        public async Task<Lot?> AddLot(Lot lot)
        {
            var created = context.Lots.Add(lot);
            await context.SaveChangesAsync();
            return created.Entity;
        }
        /// <summary>
        /// Deletes the lot record with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the lot record to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
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
