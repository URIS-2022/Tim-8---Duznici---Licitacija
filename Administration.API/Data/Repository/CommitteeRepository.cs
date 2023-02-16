using Administration.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Administration.API.Data.Repository;

/// <summary>
/// Implementation of the ICommitteeRepository
/// interface for managing Committee entities in the database.
/// </summary>
public class CommitteeRepository : ICommitteeRepository
{
    private readonly AdministrationDbContext context;

    /// <summary>
    /// Initializes a new instance of the CommitteeRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public CommitteeRepository(AdministrationDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="ICommitteeRepository.GetCommittees"/>
    public async Task<IEnumerable<Committee>> GetCommittees()
    {
        return await context.Committees.Include(c => c.CommitteeMembers)
                                                   .ThenInclude(cm => cm.Member)
                                                   .ToListAsync();
    }

    /// <inheritdoc cref="ICommitteeRepository.GetCommittee"/>
    public async Task<Committee?> GetCommittee(Guid id)
    {
        return await context.Committees.Include(c => c.CommitteeMembers)
                               .ThenInclude(cm => cm.Member)
                               .FirstOrDefaultAsync(c => c.Guid == id);
    }

    /// <inheritdoc cref="ICommitteeRepository.UpdateCommittee"/>
    public async Task<Committee?> UpdateCommittee(Guid id, Committee updateModel)
    {
        var committee = await context.Committees.Include(c => c.CommitteeMembers)
                               .ThenInclude(cm => cm.Member)
                               .FirstOrDefaultAsync(c => c.Guid == id);
        if (committee == null)
        {
            return null;
        }
        context.Entry(committee).CurrentValues.SetValues(updateModel);
        await context.SaveChangesAsync();
        return committee;
    }

    /// <inheritdoc cref="ICommitteeRepository.AddCommittee"/>
    public async Task<Committee?> AddCommittee(Committee committee)
    {
        var created = context.Committees.Add(committee);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="ICommitteeRepository.DeleteCommittee"/>
    public async Task DeleteCommittee(Guid id)
    {
        var committee = await context.Committees.FindAsync(id);
        if (committee == null)
        {
            throw new InvalidOperationException("Committee not found");
        }
        context.Committees.Remove(committee);
        await context.SaveChangesAsync();
    }
}


