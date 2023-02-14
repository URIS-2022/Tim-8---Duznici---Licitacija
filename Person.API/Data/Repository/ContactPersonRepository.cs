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
        private readonly PersonDbContext context;


        public ContactPersonRepository (PersonDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<ContactPerson>> GetAllContactPersons()
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
            var contactPerson = await GetContactPersonByGuid(ContactPersonId);
            context.ContactPersons.Remove(contactPerson);
            await context.SaveChangesAsync();
        }

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

        public async Task<bool> IsValidContactPerson(string phoneNumber)
        {
            var listOfContactPersons = await context.ContactPersons.Where(cp => cp.PhoneNumber == phoneNumber).ToListAsync();
            return listOfContactPersons.Count == 0;
        }
    }
}

