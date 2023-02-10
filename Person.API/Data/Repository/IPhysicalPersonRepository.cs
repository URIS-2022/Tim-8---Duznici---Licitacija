using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface IPhysicalPersonRepository
    {
        Task<List<PhysicalPerson>> GetAllPhysicalPersons();
        Task<PhysicalPerson> GetPhysicalPersonsByGuid(Guid PhysicalPersonId);
        Task<PhysicalPerson> CreatePhysicalPersons(PhysicalPerson physicalPerson);
        Task DeletePhysicalPersons(Guid PhysicalPersonId);
        Task UpdatePhysicalPersons(PhysicalPerson physicalPerson);

    }
}
