namespace Licitation.API.Data.Repository;

public interface ILicitationLandRepository
{
    
    /// <summary>
    /// Gets a specific committee member by its identifier.
    /// </summary>
    /// <param name="licitationId">The identifier of the Committee.</param>
    /// /// <param name="licitationLandId">The id of member to add.</param>
    /// <returns>The member with the specified identifier.</returns>
    Task<Entities.LicitationLand?> GetLicitationLand(Guid licitationId, Guid licitationLandId);

    /// <summary>
    /// Adds a new member to committee.
    /// </summary>
    /// <param name="licitationLand">The request format for adding member to commitee.</param>
    /// <returns>The added committee member.</returns>
    Task<Entities.LicitationLand?> AddLicitationLand(Entities.LicitationLand licitationLand);

    /// <summary>
    /// Removes a specific member from committee.
    /// </summary>
    /// <param name="licitationId">The identifier of the committee member to delete.</param>
    /// /// <param name="licitationLandId">The id of member to remove.</param>
    /// <returns>The deleted committee member.</returns>
    Task DeleteLicitationLand(Guid licitationId, Guid licitationLandId);
}
