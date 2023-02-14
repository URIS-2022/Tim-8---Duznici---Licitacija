using Landlot.API.Entities;

namespace Landlot.API.Data.Repository
{
    /// <summary>
    /// Represents a repository for managing land data.
    /// </summary>
    public interface ILandRepository
    {
        /// <summary>
        /// Retrieves a collection of land objects from the repository.
        /// </summary>
        /// <returns>A collection of land objects.</returns>
        Task<IEnumerable<Land>> GetLands();
        /// <summary>
        /// Retrieves a land object with the specified ID from the repository.
        /// <param name="id">The ID of the land to retrieve.</param>
        /// </summary>
        Task<Land?> GetLand(Guid id);
        /// <summary>
        /// Updates the land record with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the land record.</param>
        /// <param name="updateModel">The updated land object.</param>
        /// <returns>A boolean value indicating whether the update was successful.</returns>
        Task<Land?> UpdateLand(Guid id, Land updateModel);
        /// <summary>
        /// Adds a new land record to the repository.
        /// </summary>
        /// <param name="land">The land object to be added.</param>
        /// <returns>The unique identifier of the added land record.</returns>
        Task<Land?> AddLand(Land land);
        /// <summary>
        /// Deletes the land record with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the land record to be deleted.</param>
        /// <returns>A boolean value indicating whether the deletion was successful.</returns>
        Task DeleteLand(Guid id);
    }
}
