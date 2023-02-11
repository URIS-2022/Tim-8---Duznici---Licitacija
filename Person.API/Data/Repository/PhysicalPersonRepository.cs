﻿using AutoMapper;
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
        public async Task<List<PhysicalPerson>> GetAllPhysicalPersons()
        {
            return await context.PhysicalPersons
                .ToListAsync();
        }
        public async Task<PhysicalPerson> GetPhysicalPersonsByGuid(Guid PhysicalPersonId)
        {
            return await context.PhysicalPersons.FirstOrDefaultAsync(pp => pp.PhysicalPersonId == PhysicalPersonId);
        }

        public async Task<PhysicalPerson?> GetPhysicalPersonsByJmbg(string jmbg)
        {
            PhysicalPerson? physicalPerson = await context.PhysicalPersons.SingleOrDefaultAsync(x => x.Jmbg == jmbg);

            return physicalPerson;
        }

        public async Task<PhysicalPerson?> GetPhysicalPersonsByFirstName(string firstName)
        {
            PhysicalPerson? physicalPerson = await context.PhysicalPersons.SingleOrDefaultAsync(x => x.FirstName == firstName);

            return physicalPerson;
        }

        public async Task<PhysicalPerson?> GetPhysicalPersonsByLastName(string lastName)
        {
            PhysicalPerson? physicalPerson = await context.PhysicalPersons.SingleOrDefaultAsync(x => x.LastName == lastName);

            return physicalPerson;
        }

        public async Task<PhysicalPerson> CreatePhysicalPersons(PhysicalPerson physicalPerson)
        {
            context.PhysicalPersons.Add(physicalPerson);
            await context.SaveChangesAsync();
            return physicalPerson;
        }

        public async Task DeletePhysicalPersons(Guid PhysicalPersonId)
        {
            var physicalPerson = await GetPhysicalPersonsByGuid(PhysicalPersonId);
            context.PhysicalPersons.Remove(physicalPerson);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePhysicalPersons(PhysicalPerson physicalPerson)
        {
            await context.SaveChangesAsync();
        }
    }
}