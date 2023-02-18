using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository;

/// <summary>
/// Represents a repository for due dates.
/// </summary>
public class DueDateRepository : IDueDateRepository
{
    private readonly LeaseDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="DueDateRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public DueDateRepository(LeaseDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc cref="IDueDateRepository.GetByGuid(Guid)"/>
    public async Task<DueDate?> GetByGuid(Guid id)
    {
        return await _context.DueDates.FirstOrDefaultAsync(b => b.Guid == id);
    }

    /// <inheritdoc cref="IDueDateRepository.GetAll"/>
    public async Task<List<DueDate>> GetAll()
    {
        return await _context.DueDates.ToListAsync();
    }

    /// <inheritdoc cref="IDueDateRepository.Add(DueDate)"/>
    public async Task<DueDate?> Add(DueDate DueDate)
    {

        await _context.DueDates.AddAsync(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }

    /// <inheritdoc cref="IDueDateRepository.Update(DueDate)"/>
    public async Task<DueDate?> Update(DueDate DueDate)
    {
        _context.DueDates.Update(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }

    /// <inheritdoc cref="IDueDateRepository.Delete(Guid)"/>
    public async Task<DueDate?> Delete(Guid id)
    {
        var DueDate = await _context.DueDates.FirstOrDefaultAsync(b => b.Guid == id);
        if (DueDate == null) return null;

        _context.DueDates.Remove(DueDate);
        await _context.SaveChangesAsync();
        return DueDate;
    }
}