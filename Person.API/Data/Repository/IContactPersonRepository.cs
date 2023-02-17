using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Interface for managing contact persoons in the database.
    /// </summary>
    public interface IContactPersonRepository
    {
        /// <summary>
        /// Gets all contact persons from the database.
        /// </summary>
        /// <returns>An IEnumerable of ContactPerson.</returns>
        Task<IEnumerable<ContactPerson>> GetAllContactPersons();
        /// <summary>
        /// Gets an contact person by its unique identifier.
        /// </summary>
        /// <param name="ContactPersonId">The unique identifier of the contact perso.</param>
        /// <returns>An ContactPerson object if found; otherwise, null.</returns>
        Task<ContactPerson?> GetContactPersonByGuid(Guid ContactPersonId);
        /// <summary>
        /// Creates a new contact person in the database.
        /// </summary>
        /// <param name="contactPerson">The contact person to be created.</param>
        /// <returns>The newly created ContactPerson object.</returns>
        Task<ContactPerson> CreateContactPerson(ContactPerson contactPerson);
        /// <summary>
        /// Deletes an contact person from the database.
        /// </summary>
        /// <param name="ContactPersonId">The unique identifier of the contact person to be deleted.</param>
        Task DeleteContactPerson(Guid ContactPersonId);
        /// <summary>
        /// Updates an existing contact person in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the contact person to be updated.</param>
        /// <param name="updateModel">The updated contact person data.</param>
        /// <returns>The updated ContactPerson object if successful; otherwise, null.</returns>
        Task<ContactPerson?> UpdateContactPerson(Guid id, ContactPerson updateModel);
    }
}