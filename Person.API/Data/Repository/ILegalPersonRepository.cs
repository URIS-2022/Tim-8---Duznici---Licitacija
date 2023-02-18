using Person.API.Entities;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Interface for managing legal persons in the database.
    /// </summary>
    public interface ILegalPersonRepository
    {
        /// <summary>
        /// Gets all legal persons from the database.
        /// </summary>
        /// <returns>An IEnumerable of LegalPerson.</returns>
        Task<IEnumerable<LegalPerson>> GetAllLegalPersons();
        /// <summary>
        /// Gets an legal person by its unique identifier.
        /// </summary>
        /// <param name="LegalPersonId">The unique identifier of the legal person.</param>
        /// <returns>An LegalPerson object if found; otherwise, null.</returns>
        Task<LegalPerson?> GetLegalPersonByGuid(Guid LegalPersonId);
        /// <summary>
        /// Creates a new legal person in the database.
        /// </summary>
        /// <param name="legalPerson">The legal person to be created.</param>
        /// <returns>The newly created LegalPerson object.</returns>
        Task<LegalPerson> CreateLegalPerson(LegalPerson legalPerson);
        /// <summary>
        /// Deletes an legal person from the database.
        /// </summary>
        /// <param name="LegalPersonId">The unique identifier of the legal person to be deleted.</param>
        Task DeleteLegalPerson(Guid LegalPersonId);
        /// <summary>
        /// Updates an existing legal person in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the legal person to be updated.</param>
        /// <param name="updateModel">The updated legal person data.</param>
        /// <returns>The updated LegalPerson object if successful; otherwise, null.</returns>
        Task<LegalPerson?> UpdateLegalPerson(Guid id, LegalPerson updateModel);

    }
}
