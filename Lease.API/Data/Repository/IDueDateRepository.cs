﻿using Lease.API.Entities;

namespace Lease.API.Data.Repository;

public interface IDueDateRepository
{
    Task<DueDate> GetByGuid(Guid id);
    Task<List<DueDate>> GetAll();
    Task<DueDate> Add(DueDate DueDate);
    Task<DueDate> Update(DueDate DueDate);
    Task<DueDate> Delete(Guid id);

}

