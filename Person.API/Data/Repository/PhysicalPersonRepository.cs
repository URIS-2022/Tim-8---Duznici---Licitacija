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
    public class PhysicalPersonRepository : IPhysicalPersonRepository
    {
        private readonly PersonDbContext context;


        public PhysicalPersonRepository(PersonDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<PhysicalPerson>> GetAllPhysicalPersons()
        {
            return await context.PhysicalPersons
                .ToListAsync();
        }

        public async Task<PhysicalPerson> GetPhysicalPersonByGuid(Guid PhysicalPersonId)
        {
            return await context.PhysicalPersons.FirstOrDefaultAsync(p => p.PhysicalPersonId == PhysicalPersonId);
        }

        public async Task<PhysicalPerson> CreatePhysicalPerson(PhysicalPerson physicalPerson)
        {
            context.PhysicalPersons.Add(physicalPerson);
            await context.SaveChangesAsync();
            return physicalPerson;
        }

        public async Task DeletePhysicalPerson(Guid PhysicalPersonId)
        {
            var physicalPerson = await GetPhysicalPersonByGuid(PhysicalPersonId);
            context.PhysicalPersons.Remove(physicalPerson);
            await context.SaveChangesAsync();
        }

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