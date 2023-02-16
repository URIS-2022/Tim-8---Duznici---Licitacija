using Administration.API.Entities;

namespace Administration.API.Data.Repository;

/// <summary>
/// The interface for committee member repository, provides methods for getting, updating, adding and deleting a committee member
/// </summary>
public interface ICommitteeMemberRepository
{
    /// <summary>
    /// Gets a specific committee member by its identifier.
    /// </summary>
    /// <param name="committeeId">The identifier of the Committee.</param>
    /// /// <param name="memberId">The id of member to add.</param>
    /// <returns>The member with the specified identifier.</returns>
    Task<CommitteeMember?> GetCommitteeMember(Guid committeeId, Guid memberId);

    /// <summary>
    /// Adds a new member to committee.
    /// </summary>
    /// <param name="committeeMember">The request format for adding member to commitee.</param>
    /// <returns>The added committee member.</returns>
    Task<CommitteeMember?> AddCommitteeMember(CommitteeMember committeeMember);

    /// <summary>
    /// Updates a specific commitee member.
    /// </summary>
    /// <param name="updateModel">The updated values for the member.</param>
    /// <returns>The updated commitee member.</returns>
    Task<CommitteeMember?> UpdateCommitteeMember(CommitteeMember updateModel);

    /// <summary>
    /// Removes a specific member from committee.
    /// </summary>
    /// <param name="committeeId">The identifier of the committee member to delete.</param>
    /// /// <param name="memberId">The id of member to remove.</param>
    /// <returns>The deleted committee member.</returns>
    Task DeleteCommitteeMember(Guid committeeId, Guid memberId);
}
