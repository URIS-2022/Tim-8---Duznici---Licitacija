using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface ILegalPersonRepository
    {
        Task<IEnumerable<LegalPerson>> GetAllLegalPersons();
        Task<LegalPerson?> GetLegalPersonByGuid(Guid LegalPersonId);
        Task<LegalPerson?> CreateLegalPerson(LegalPerson? legalPerson);
        Task DeleteLegalPerson(Guid LegalPersonId);
        Task<LegalPerson?> UpdateLegalPerson(Guid id, LegalPerson legalPerson);

    }
}
