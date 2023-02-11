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
        public async Task<List<LegalPerson>> GetAllLegalPersons()
        {
            return await context.LegalPersons
                .ToListAsync();
        }
        public async Task<LegalPerson> GetLegalPersonsByGuid(Guid LegalPersonId)
        {
            return await context.LegalPersons.FirstOrDefaultAsync(pp => pp.LegalPersonId == LegalPersonId);
        }

        public async Task<LegalPerson?> GetLegalPersonsByName(string name)
        {
            LegalPerson? legalPerson = await context.LegalPersons.SingleOrDefaultAsync(x => x.Name == name);

            return legalPerson;
        }

        public async Task<LegalPerson?> GetLegalPersonsByIdentificationNumber(string identificatioNnumber)
        {
            LegalPerson? legalPerson = await context.LegalPersons.SingleOrDefaultAsync(x => x.IdentificationNumber == identificatioNnumber);

            return legalPerson;
        }
        public async Task<LegalPerson> CreateLegalPersons(LegalPerson legalPerson)
        {
            context.LegalPersons.Add(legalPerson);
            await context.SaveChangesAsync();
            return legalPerson;
        }

        public async Task DeleteLegalPersons(Guid LegalPersonId)
        {
            var legalPerson = await GetLegalPersonsByGuid(LegalPersonId);
            context.LegalPersons.Remove(legalPerson);
            await context.SaveChangesAsync();
        }

        public async Task UpdateLegalPersons(LegalPerson legalPerson)
        {
            await context.SaveChangesAsync();
        }
    }
}