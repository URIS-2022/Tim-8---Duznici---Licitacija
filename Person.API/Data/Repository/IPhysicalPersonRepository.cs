using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Interface for managing physical persons in the database.
    /// </summary>
    public interface IPhysicalPersonRepository
    {
        /// <summary>
        /// Gets all physical persons from the database.
        /// </summary>
        /// <returns>An IEnumerable of PhysicalPerson.</returns>
        Task<IEnumerable<PhysicalPerson>> GetAllPhysicalPersons();
        /// <summary>
        /// Gets an physical person by its unique identifier.
        /// </summary>
        /// <param name="PhysicalPersonId">The unique identifier of the physical person.</param>
        /// <returns>An PhysicalPerson object if found; otherwise, null.</returns>
        Task<PhysicalPerson?> GetPhysicalPersonByGuid(Guid PhysicalPersonId);
        /// <summary>
        /// Creates a new physical person in the database.
        /// </summary>
        /// <param name="physicalPerson">The physical person to be created.</param>
        /// <returns>The newly created PhysicalPerson object.</returns>
        Task<PhysicalPerson?> CreatePhysicalPerson(PhysicalPerson? physicalPerson);
        /// <summary>
        /// Deletes an physical person from the database.
        /// </summary>
        /// <param name="PhysicalPersonId">The unique identifier of the physical person to be deleted.</param>
        Task DeletePhysicalPerson(Guid PhysicalPersonId);
        /// <summary>
        /// Updates an existing physical person in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the physical person to be updated.</param>
        /// <param name="physicalPerson">The updated physical person data.</param>
        /// <returns>The updated PhysicalPerson object if successful; otherwise, null.</returns>
        Task<PhysicalPerson?> UpdatePhysicalPerson(Guid id, PhysicalPerson physicalPerson);

    }
}
