using AutoMapper;
using Person.API.Entities;
using Person.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository

{
    /// <summary>
    /// Provides CRUD operations for the PhysicalPerson entity.
    /// </summary>
    public class PhysicalPersonRepository : IPhysicalPersonRepository
    {
        private readonly PersonDbContext context;

        /// <summary>
        /// Creates a new instance of the PhysicalPersonRepository class.
        /// </summary>
        /// <param name="context">The PersonDbContext object.</param>
        public PhysicalPersonRepository(PersonDbContext context)
        {
            this.context = context;

        }
        /// <summary>
        /// Retrieves all physical persons from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of PhysicalPerson objects.</returns>
        public async Task<IEnumerable<PhysicalPerson>> GetAllPhysicalPersons()
        {
            return await context.PhysicalPersons
                .ToListAsync();
        }
        /// <summary>
        /// Retrieves an physical person from the database by its ID.
        /// </summary>
        /// <param name="PhysicalPersonId">The ID of the physical person to retrieve.</param>
        /// <returns>The PhysicalPerson object with the specified ID, or null if no such physical person exists.</returns>
        public async Task<PhysicalPerson> GetPhysicalPersonByGuid(Guid PhysicalPersonId)
        {
            return await context.PhysicalPersons.FirstOrDefaultAsync(p => p.PhysicalPersonId == PhysicalPersonId);
        }
        /// <summary>
        /// Adds a new physical person to the database.
        /// </summary>
        /// <param name="physicalPerson">The PhysicalPerson object to be added.</param>
        /// <returns>The PhysicalPerson object that was added to the database.</returns>
        public async Task<PhysicalPerson> CreatePhysicalPerson(PhysicalPerson physicalPerson)
        {
            context.PhysicalPersons.Add(physicalPerson);
            await context.SaveChangesAsync();
            return physicalPerson;
        }
        /// <summary>
        /// Deletes an physical person from the database by its ID.
        /// </summary>
        /// <param name="PhysicalPersonId">The ID of the physical person to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeletePhysicalPerson(Guid PhysicalPersonId)
        {
            var physicalPerson = await GetPhysicalPersonByGuid(PhysicalPersonId);
            context.PhysicalPersons.Remove(physicalPerson);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Updates an existing physical person in the database.
        /// </summary>
        /// <param name="id">The ID of the physical person to update.</param>
        /// <param name="updateModel">The updated PhysicalPerson object.</param>
        /// <returns>The PhysicalPerson object that was updated in the database, or null if no such physical person exists.</returns>
        public async Task<PhysicalPerson?> UpdatePhysicalPerson(Guid id, PhysicalPerson updateModel)
        {
            var physicalPerson = await context.PhysicalPersons.FirstOrDefaultAsync(P => P.PhysicalPersonId == id);
            if (physicalPerson == null)
            {
                return null;
            }
            context.Entry(physicalPerson).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return physicalPerson;
        }

    }
}