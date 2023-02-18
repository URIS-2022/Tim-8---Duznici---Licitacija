using Lease.API.Entities;

namespace Lease.API.Data.Repository;

public interface IBuyerRepository
{
    Task<Buyer> GetByGuid(Guid id);
    Task<List<Buyer>> GetAll();
    Task<Buyer> Add(Buyer buyer);
    Task<Buyer> Update(Buyer buyer);
    Task<Buyer> Delete(Guid id);
}

