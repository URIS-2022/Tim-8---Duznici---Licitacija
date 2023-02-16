using AutoMapper;
using Person.API.Data;
using Person.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Provides CRUD operations for the Contact person entity.
    /// </summary>
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly PersonDbContext context;

        /// <summary>
        /// Creates a new instance of the ContactPersonRepository class.
        /// </summary>
        /// <param name="context">The PersonDbContext object.</param>
        public ContactPersonRepository (PersonDbContext context)
        {
            this.context = context;

        }
        /// <summary>
        /// Retrieves all contact persons from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of ContactPerson objects.</returns>
        public async Task<IEnumerable<ContactPerson>> GetAllContactPersons()
        {
            return await context.ContactPersons
                .ToListAsync();
        }
        /// <summary>
        /// Retrieves an contact person from the database by its ID.
        /// </summary>
        /// <param name="ContactPersonId">The ID of the contact person to retrieve.</param>
        /// <returns>The ContactPerson object with the specified ID, or null if no such contact person exists.</returns>
        public async Task<ContactPerson?> GetContactPersonByGuid(Guid ContactPersonId)
        {
            return await context.ContactPersons
                .FirstOrDefaultAsync(ko => ko.ContactPersonId == ContactPersonId);
        }

        /// <summary>
        /// Adds a new contact person to the database.
        /// </summary>
        /// <param name="contactPerson">The ContactPerson object to be added.</param>
        /// <returns>The ContactPerson object that was added to the database.</returns>
        public async Task<ContactPerson> CreateContactPerson(ContactPerson contactPerson)
        {
            context.ContactPersons.Add(contactPerson);
            await context.SaveChangesAsync();
            return contactPerson;
        }
        /// <summary>
        /// Deletes an contact person from the database by its ID.
        /// </summary>
        /// <param name="ContactPersonId">The ID of the contact person to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteContactPerson(Guid ContactPersonId)
        {
            var contactPerson = await GetContactPersonByGuid(ContactPersonId);
            context.ContactPersons.Remove(contactPerson);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Updates an existing contact person in the database.
        /// </summary>
        /// <param name="id">The ID of the contact person to update.</param>
        /// <param name="updateModel">The updated ContactPerson object.</param>
        /// <returns>The ContactPerson object that was updated in the database, or null if no such contact person exists.</returns>
        public async Task<ContactPerson?> UpdateContactPerson(Guid id,ContactPerson updateModel)
        {
            var contactPerson = await context.ContactPersons.FirstOrDefaultAsync(c => c.ContactPersonId == id);
            if (contactPerson == null)
            {
                return null;
            }
            context.Entry(contactPerson).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return contactPerson;
        }

        
    }
}

