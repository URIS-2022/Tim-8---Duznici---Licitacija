using Landlot.API.Entities;


namespace Landlot.API.Data.Repository
{
    /// <summary>
    /// Represents a repository for managing lot data.
    /// </summary>
    public interface ILotRepository
    {
        /// <summary>
        /// Retrieves a collection of lot objects from the repository.
        /// </summary>
        /// <returns>A collection of lot objects.</returns>
        Task<IEnumerable<Lot>> GetLots();
        /// <summary>
        /// Retrieves a lot object with the specified ID from the repository.
        /// <param name="id">The ID of the lot to retrieve.</param>
        /// </summary>
        Task<Lot?> GetLot(Guid id);
        /// <summary>
        /// Updates the lot record with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the lot record.</param>
        /// <param name="updateModel">The updated lot object.</param>
        /// <returns>A boolean value indicating whether the update was successful.</returns>
        Task<Lot?> UpdateLot(Guid id, Lot updateModel);
        /// <summary>
        /// Adds a new lot record to the repository.
        /// </summary>
        /// <param name="lot">The lot object to be added.</param>
        /// <returns>The unique identifier of the added lot record.</returns>
        Task<Lot?> AddLot(Lot lot);
        /// <summary>
        /// Deletes the lot record with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the lot record to be deleted.</param>
        /// <returns>A boolean value indicating whether the deletion was successful.</returns>
        Task DeleteLot(Guid id);
    }
}
