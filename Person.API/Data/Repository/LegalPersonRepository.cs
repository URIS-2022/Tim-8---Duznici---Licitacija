using Person.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Person.API.Data.Repository

{
    /// <summary>
    /// Provides CRUD operations for the LegalPerson entity.
    /// </summary>
    public class LegalPersonRepository : ILegalPersonRepository
    { 
        private readonly PersonDbContext context;

        /// <summary>
        /// Creates a new instance of the LegalPersonRepository class.
        /// </summary>
        /// <param name="context">The PersonDbContext object.</param>
        public LegalPersonRepository(PersonDbContext context)
        {
            this.context = context;

        }
        /// <summary>
        /// Retrieves all legal persons from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of LegalPerson objects.</returns>
        public async Task<IEnumerable<LegalPerson>> GetAllLegalPersons()
        {

            return await context.LegalPersons
                .Include(a => a.Address)
                .Include(c => c.ContactPerson)
                .ToListAsync();
        }
        /// <summary>
        /// Retrieves an legal person from the database by its ID.
        /// </summary>
        /// <param name="LegalPersonId">The ID of the legal person to retrieve.</param>
        /// <returns>The LegalPerson object with the specified ID, or null if no such legal person exists.</returns>
        public async Task<LegalPerson?> GetLegalPersonByGuid(Guid LegalPersonId)
        {

            return await context.LegalPersons
                .Include(a => a.Address)
                .Include(c => c.ContactPerson)
                .FirstOrDefaultAsync(o => o.LegalPersonId == LegalPersonId);
            
        }
        /// <summary>
        /// Adds a new legal person to the database.
        /// </summary>
        /// <param name="legalPerson">The LegalPerson object to be added.</param>
        /// <returns>The LegalPerson object that was added to the database.</returns>
        public async Task<LegalPerson> CreateLegalPerson(LegalPerson legalPerson)
        {
            context.LegalPersons.Add(legalPerson);
            await context.SaveChangesAsync();
            return legalPerson;
        }
        /// <summary>
        /// Deletes an legal person from the database by its ID.
        /// </summary>
        /// <param name="LegalPersonId">The ID of the legal person to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteLegalPerson(Guid LegalPersonId)
        {
            var legalPerson = await GetLegalPersonByGuid(LegalPersonId);
            if(legalPerson != null)
            {
                context.LegalPersons.Remove(legalPerson);
                await context.SaveChangesAsync();
            }
            
        }
        /// <summary>
        /// Updates an existing legal person in the database.
        /// </summary>
        /// <param name="id">The ID of the legal person to update.</param>
        /// <param name="updateModel">The updated LegalPerson object.</param>
        /// <returns>The LegalPerson object that was updated in the database, or null if no such legal person exists.</returns>
        public async Task<LegalPerson?> UpdateLegalPerson(Guid id, LegalPerson updateModel)
        {
            var legalPerson = await context.LegalPersons.FirstOrDefaultAsync(c => c.LegalPersonId == id);
            if (legalPerson == null)
            {
                return null;
            }
            context.Entry(legalPerson).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return legalPerson;
        }

    }
}