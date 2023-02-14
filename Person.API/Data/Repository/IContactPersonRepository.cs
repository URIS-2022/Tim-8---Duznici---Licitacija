using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface IContactPersonRepository
    {
        Task<IEnumerable<ContactPerson>> GetAllContactPersons();
        Task<ContactPerson?> GetContactPersonByGuid(Guid ContactPersonId);
        Task<ContactPerson?> CreateContactPerson(ContactPerson? contactPerson);
        Task DeleteContactPerson(Guid ContactPersonId);
        Task<ContactPerson?> UpdateContactPerson(Guid id, ContactPerson contactPerson);
    }
}