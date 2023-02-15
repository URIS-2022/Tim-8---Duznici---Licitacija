using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;
using Lease.API.Data;

namespace Lease.API.Data.Repository;

public class DueDateRepository : IDueDateRepository
{
    private readonly LeaseDbContext _context;

    public DueDateRepository(LeaseDbContext context)
    {
        _context = context;
    }

    public async Task<DueDate> GetById(int id)
    {
        return await _context.DueDates.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<DueDate>> GetAll()
    {
        return await _context.DueDates.ToListAsync();
    }

    public async Task<DueDate> Add(DueDate DueDate)
    {
        
        await _context.DueDates.AddAsync(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }

    public async Task<DueDate> Update(DueDate DueDate)
    {
        _context.DueDates.Update(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }

    public async Task<DueDate> Delete(int id)
    {
        var DueDate = await _context.DueDates.FirstOrDefaultAsync(b => b.Id == id);
        if (DueDate == null) return null;

        _context.DueDates.Remove(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }

    public async Task<DueDate> GetByDate(DateTime date)
    {
        var DueDate = await _context.DueDates.FirstOrDefaultAsync(b => b.Date == date);
        if (DueDate == null) return null;

        _context.DueDates.Remove(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }
}