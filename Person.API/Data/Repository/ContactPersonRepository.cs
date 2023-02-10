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
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly PersonContext context;


        public ContactPersonRepository(PersonContext context)
        {
            context = context;

        }

        public async Task<List<ContactPerson>> GetAllContactPersons()
        {
            return await context.ContactPersons
                .ToListAsync();
        }

        public async Task<ContactPerson> GetContactPersonByGuid(Guid ContactPersonId)
        {
            return await context.ContactPersons.FirstOrDefaultAsync(ko => ko.ContactPersonId == ContactPersonId);
        }
        public async Task<ContactPerson> CreateContactPerson(ContactPerson contactPerson)
        {
            context.ContactPersons.Add(contactPerson);
            await context.SaveChangesAsync();
            return contactPerson;
        }

        public async Task DeleteContactPersons(Guid ContactPersonId)
        {
            var contactPerson = await GetContactPersonById(ContactPersonId);
            context.ContactPersons.Remove(contactPerson);
            await context.SaveChangesAsync();
        }

        public async Task UpdateContactPersons(ContactPerson contactPerson)
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsValidContactPerson(string phoneNumber)
        {
            var listOfContactPersons = await context.ContactPersons.Where(cp => cp.PhoneNumber == phoneNumber).ToListAsync();
            return listOfContactPersons.Count == 0;
        }
    }
}

