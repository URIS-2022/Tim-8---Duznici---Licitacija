using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface IContactPersonRepository
    {
        Task<List<ContactPerson>> GetAllContactPersons();
        Task<ContactPerson> GetContactPersonByGuid(Guid ContactPersonId);
        Task<ContactPerson> CreateContactPerson(ContactPerson contactPerson);
        Task DeleteContactPersons(Guid ContactPersonId);
        Task UpdateContactPersons(ContactPerson contactPerson);
        Task<bool> IsValidContactPerson(string phoneNumber);
    }
}