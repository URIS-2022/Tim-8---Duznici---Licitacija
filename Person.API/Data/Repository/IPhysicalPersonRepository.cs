using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public interface IPhysicalPersonRepository
    {
        Task<IEnumerable<PhysicalPerson>> GetAllPhysicalPersons();
        Task<PhysicalPerson?> GetPhysicalPersonByGuid(Guid PhysicalPersonId);
        Task<PhysicalPerson?> CreatePhysicalPerson(PhysicalPerson? physicalPerson);
        Task DeletePhysicalPerson(Guid PhysicalPersonId);
        Task<PhysicalPerson?> UpdatePhysicalPerson(Guid id, PhysicalPerson physicalPerson);

    }
}
