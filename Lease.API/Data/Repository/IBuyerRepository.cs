using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;
using Lease.API.Models;

namespace Lease.API.Data.Repository;

    public interface IBuyerRepository
    {
        Task<Buyer> GetByGuid(Guid id);
        Task<List<Buyer>> GetAll();
        Task<Buyer> Add(Buyer buyer);
        Task<Buyer> Update(Buyer buyer);
        Task<Buyer> Delete(Guid id);
    }

