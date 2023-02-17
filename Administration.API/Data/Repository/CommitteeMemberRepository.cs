using Administration.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Administration.API.Data.Repository;

/// <summary>
/// Implementation of the ICommitteeMemberRepository
/// interface for managing CommitteeMember entities in the database.
/// </summary>
public class CommitteeMemberRepository : ICommitteeMemberRepository
{
    private readonly AdministrationDbContext context;

    /// <summary>
    /// Initializes a new instance of the CommitteeMemberRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public CommitteeMemberRepository(AdministrationDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="ICommitteeMemberRepository.GetCommitteeMember"/>
    public async Task<CommitteeMember?> GetCommitteeMember(Guid committeeId, Guid memberId)
    {
        return await context.CommitteeMembers.FirstOrDefaultAsync(c => c.MemberGuid == memberId && c.CommitteeGuid == committeeId);
    }

    /// <inheritdoc cref="ICommitteeMemberRepository.UpdateCommitteeMember"/>
    public async Task<CommitteeMember?> UpdateCommitteeMember(CommitteeMember updateModel)
    {
        var committeeMember = await context.CommitteeMembers.FirstOrDefaultAsync(c => c.CommitteeGuid == updateModel.CommitteeGuid);
        if (committeeMember == null)
        {
            return null;
        }
        context.Entry(committeeMember).CurrentValues.SetValues(updateModel);
        await context.SaveChangesAsync();
        return committeeMember;
    }

    /// <inheritdoc cref="ICommitteeMemberRepository.AddCommitteeMember"/>
    public async Task<CommitteeMember?> AddCommitteeMember(CommitteeMember committeeMember)
    {
        var created = context.CommitteeMembers.Add(committeeMember);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="ICommitteeMemberRepository.DeleteCommitteeMember"/>
    public async Task DeleteCommitteeMember(Guid committeeId, Guid memberId)
    {
        var committeeMember = await context.CommitteeMembers.FirstOrDefaultAsync(c => c.MemberGuid == memberId && c.CommitteeGuid == committeeId);
        if (committeeMember == null)
        {
            throw new InvalidOperationException("Committee member not found");
        }
        context.CommitteeMembers.Remove(committeeMember);
        await context.SaveChangesAsync();
    }
}


