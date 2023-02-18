namespace Licitation.API.Data.Repository;

public interface ILicitationLandRepository
{

    /// <summary>
    /// Gets a specific licitation land by its identifier.
    /// </summary>
    /// <param name="licitationId">The identifier of the Licitation.</param>
    /// /// <param name="licitationLandId">The id of land to add.</param>
    /// <returns>The land with the specified identifier.</returns>
    Task<Entities.LicitationLand?> GetLicitationLand(Guid licitationId, Guid licitationLandId);

    /// <summary>
    /// Adds a new land to licitation.
    /// </summary>
    /// <param name="licitationLand">The request format for adding land to licitation.</param>
    /// <returns>The added licitation land.</returns>
    Task<Entities.LicitationLand?> AddLicitationLand(Entities.LicitationLand licitationLand);

    /// <summary>
    /// Removes a specific land from licitation.
    /// </summary>
    /// <param name="licitationId">The identifier of the licitation land to delete.</param>
    /// /// <param name="licitationLandId">The id of land to remove.</param>
    /// <returns>The deleted licitation land.</returns>
    Task DeleteLicitationLand(Guid licitationId, Guid licitationLandId);
}
