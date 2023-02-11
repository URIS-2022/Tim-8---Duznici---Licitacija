using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface ILegalPersonRepository
    {
        Task<List<LegalPerson>> GetAllLegalPersons();
        Task<LegalPerson> GetLegalPersonsByGuid(Guid LegalPersonId);
        Task<LegalPerson?> GetLegalPersonsByName(string name);
        Task<LegalPerson?> GetLegalPersonsByIdentificationNumber(string identificatioNnumber);
        Task<LegalPerson> CreateLegalPersons(LegalPerson legalPerson);
        Task DeleteLegalPersons(Guid LegalPersonId);
        Task UpdateLegalPersons(LegalPerson legalPerson);

    }
}
