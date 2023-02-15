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
    public class LegalPersonRepository : ILegalPersonRepository
    { 
        private readonly PersonDbContext context;


        public LegalPersonRepository(PersonDbContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<LegalPerson>> GetAllLegalPersons()
        {
            return await context.LegalPersons
                .ToListAsync();
        }

        public async Task<LegalPerson> GetLegalPersonByGuid(Guid LegalPersonId)
        {
            return await context.LegalPersons.FirstOrDefaultAsync(o => o.LegalPersonId == LegalPersonId);
            
        }

        public async Task<LegalPerson> CreateLegalPerson(LegalPerson legalPerson)
        {
            context.LegalPersons.Add(legalPerson);
            await context.SaveChangesAsync();
            return legalPerson;
        }

        public async Task DeleteLegalPerson(Guid LegalPersonId)
        {
            var legalPerson = await GetLegalPersonByGuid(LegalPersonId);
            context.LegalPersons.Remove(legalPerson);
            await context.SaveChangesAsync();
        }

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