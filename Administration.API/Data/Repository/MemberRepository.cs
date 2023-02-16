using Administration.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Administration.API.Data.Repository;

/// <summary>
/// Implementation of the IMemberRepository
/// interface for managing Member entities in the database.
/// </summary>
public class MemberRepository : IMemberRepository
{
    private readonly AdministrationDbContext context;

    /// <summary>
    /// Initializes a new instance of the MemberRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public MemberRepository(AdministrationDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IMemberRepository.GetMembers"/>
    public async Task<IEnumerable<Member>> GetMembers()
    {
        return await context.Members.Include(c => c.CommitteeMembers)
                                                   .ThenInclude(cm => cm.Committee)
                                                   .ToListAsync();
    }

    /// <inheritdoc cref="IMemberRepository.GetMember"/>
    public async Task<Member?> GetMember(Guid id)
    {
        return await context.Members.Include(c => c.CommitteeMembers)
                               .ThenInclude(cm => cm.Committee)
                               .FirstOrDefaultAsync(c => c.Guid == id);
    }

    /// <inheritdoc cref="IMemberRepository.UpdateMember"/>
    public async Task<Member?> UpdateMember(Guid id, Member updateModel)
    {
        var member = await context.Members.Include(c => c.CommitteeMembers)
                               .ThenInclude(cm => cm.Committee)
                               .FirstOrDefaultAsync(c => c.Guid == id);
        if (member == null)
        {
            return null;
        }
        context.Entry(member).CurrentValues.SetValues(updateModel);
        await context.SaveChangesAsync();
        return member;
    }

    /// <inheritdoc cref="IMemberRepository.AddMember"/>
    public async Task<Member?> AddMember(Member member)
    {
        var created = context.Members.Add(member);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="IMemberRepository.DeleteMember"/>
    public async Task DeleteMember(Guid id)
    {
        var member = await context.Members.FindAsync(id);
        if (member == null)
        {
            throw new InvalidOperationException("Member not found");
        }
        context.Members.Remove(member);
        await context.SaveChangesAsync();
    }
}


