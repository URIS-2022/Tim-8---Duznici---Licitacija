using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;

namespace Lease.API.Data.Repository;

    public interface IDueDateRepository
    {
        Task<DueDate> GetById(int id);
        Task<List<DueDate>> GetAll();
        Task<DueDate> Add(DueDate DueDate);
        Task<DueDate> Update(DueDate DueDate);
        Task<DueDate> Delete(int id);
        Task<DueDate> GetByDate(DateTime date);
}

