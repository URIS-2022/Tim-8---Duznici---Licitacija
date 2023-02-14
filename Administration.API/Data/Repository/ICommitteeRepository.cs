using Administration.API.Entities;

namespace Administration.API.Data.Repository;

/// <summary>
/// The interface for committee repository, provides methods for getting, updating, adding and deleting a committee
/// </summary>
public interface ICommitteeRepository
{
    /// <summary>
    /// Gets a list of all committees.
    /// </summary>
    /// <returns>A list of committees.</returns>
    Task<IEnumerable<Committee>> GetCommittees();

    /// <summary>
    /// Gets a specific committee by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the committee.</param>
    /// <returns>The committee with the specified identifier.</returns>
    Task<Committee?> GetCommittee(Guid id);

    /// <summary>
    /// Updates a specific committee.
    /// </summary>
    /// <param name="id">The identifier of the committee to update.</param>
    /// <param name="patchDocument">The updated values for the committee.</param>
    /// <returns>The updated committee.</returns>
    Task<Committee?> UpdateCommittee(Guid id, Committee patchDocument);

    /// <summary>
    /// Adds a new committee.
    /// </summary>
    /// <param name="committee">The committee to add.</param>
    /// <returns>The added committee.</returns>
    Task<Committee?> AddCommittee(Committee committee);

    /// <summary>
    /// Deletes a specific committee.
    /// </summary>
    /// <param name="id">The identifier of the committee to delete.</param>
    /// <returns>The deleted committee.</returns>
    Task DeleteCommittee(Guid id);
}
