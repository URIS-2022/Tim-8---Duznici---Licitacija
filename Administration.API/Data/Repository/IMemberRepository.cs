using Administration.API.Entities;

namespace Administration.API.Data.Repository;

/// <summary>
/// The interface for member repository, provides methods for getting, updating, adding and deleting a member
/// </summary>
public interface IMemberRepository
{
    /// <summary>
    /// Gets a list of all members.
    /// </summary>
    /// <returns>A list of members.</returns>
    Task<IEnumerable<Member>> GetMembers();

    /// <summary>
    /// Gets a specific member by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the member.</param>
    /// <returns>The member with the specified identifier.</returns>
    Task<Member?> GetMember(Guid id);

    /// <summary>
    /// Updates a specific member.
    /// </summary>
    /// <param name="id">The identifier of the member to update.</param>
    /// <param name="patchDocument">The updated values for the member.</param>
    /// <returns>The updated member.</returns>
    Task<Member?> UpdateMember(Guid id, Member patchDocument);

    /// <summary>
    /// Adds a new member.
    /// </summary>
    /// <param name="member">The member to add.</param>
    /// <returns>The added member.</returns>
    Task<Member?> AddMember(Member member);

    /// <summary>
    /// Deletes a specific member.
    /// </summary>
    /// <param name="id">The identifier of the member to delete.</param>
    /// <returns>The deleted member.</returns>
    Task DeleteMember(Guid id);
}
