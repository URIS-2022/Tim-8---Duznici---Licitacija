using Licitation.API.Entities;

namespace Licitation.API.Data.Repository
{
    /// <summary>
    /// Repository for managing Licitation entities.
    /// </summary>
    public interface ILicitationRepository
    {
        /// <summary>
        /// Gets all Licitations from the database.
        /// </summary>
        /// <returns>An asynchronous task that returns an enumerable of Licitations entities.</returns>
        Task<IEnumerable<LicitationEntity>> GetAll();

        /// <summary>
        /// Gets a Licitation by its Guid identifier.
        /// </summary>
        /// <param name="guid">The Guid identifier of the Licitation.</param>
        /// <returns>An asynchronous task that returns the Licitation entity with the specified Guid identifier, or null if no such entity exists.</returns>
        Task<LicitationEntity?> GetByGuid(Guid guid);

        /// <summary>
        /// Gets a Licitation by its date.
        /// </summary>
        /// <param name="date">The username of the Licitation.</param>
        /// <returns>An asynchronous task that returns the Licitation entity with the specified username, or null if no such entity exists.</returns>
        Task<LicitationEntity?> GetByDate(string date);

        /// <summary>
        /// Adds a new Licitation to the database.
        /// </summary>
        /// <param name="licitation">The Licitation entity to add to the database.</param>
        /// <returns>An asynchronous task that returns the added Licitation entity.</returns>
        Task<LicitationEntity?> Add(LicitationEntity licitation);

        /// <summary>
        /// Updates an existing Licitation in the database.
        /// </summary>
        /// <param name="licitation">The Licitation entity to update in the database.</param>
        /// <returns>An asynchronous task that returns the updated Licitation entity.</returns>
        Task<LicitationEntity?> Update(LicitationEntity licitation);

        /// <summary>
        /// Deletes a Licitation from the database by its Guid identifier.
        /// </summary>
        /// <param name="guid">The Guid identifier of the Licitation to delete.</param>
        /// <returns>An asynchronous task that represents the operation.</returns>
        Task Delete(Guid guid);

        /// <summary>
        /// Deletes a Licitation from the database by its username.
        /// </summary>
        /// <param name="date">The username of the Licitation to delete.</param>
        /// <returns>An asynchronous task that represents the operation.</returns>
        Task Delete(string date);
    }
}
