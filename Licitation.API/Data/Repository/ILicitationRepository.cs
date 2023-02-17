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
        Task<IEnumerable<Entities.Licitation>> GetAll();

        /// <summary>
        /// Gets a Licitation by its Guid identifier.
        /// </summary>
        /// <param name="id">The Guid identifier of the Licitation.</param>
        /// <returns>An asynchronous task that returns the Licitation entity with the specified Guid identifier, or null if no such entity exists.</returns>
        Task<Entities.Licitation?> GetByGuid(Guid id);

        /// <summary>
        /// Deletes a Licitation from the database by its Guid identifier.
        /// </summary>
        /// <param name="id">The Guid identifier of the Licitation to delete.</param>
        /// <returns>An asynchronous task that represents the operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Adds a new Licitation to the database.
        /// </summary>
        /// <param name="licitation">The Licitation entity to add to the database.</param>
        /// <returns>An asynchronous task that returns the added Licitation entity.</returns>
        Task<Entities.Licitation?> AddLicitation(Entities.Licitation licitation);

        /// <summary>
        /// Updates a specific licitation.
        /// </summary>
        /// <param name="id">The identifier of the licitation to update.</param>
        /// <param name="patchDocument">The updated values for the licitation.</param>
        /// <returns>The updated licitation.</returns>
        Task<Entities.Licitation?> UpdateLicitation(Guid id, Entities.Licitation patchDocument);


        /* /// <summary>
        /// Gets a Licitation by its date.
        /// </summary>
        /// <param name="date">The username of the Licitation.</param>
        /// <returns>An asynchronous task that returns the Licitation entity with the specified username, or null if no such entity exists.</returns>
        Task<LicitationEntity?> GetByDate(DateTime date);*/


        /// <summary>
        /// Deletes a Licitation from the database by its username.
        /// </summary>
        /// <param name="date">The username of the Licitation to delete.</param>
        /// <returns>An asynchronous task that represents the operation.</returns>
       // Task Delete(string date);
    }
}
