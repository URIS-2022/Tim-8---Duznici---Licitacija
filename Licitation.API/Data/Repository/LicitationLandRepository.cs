using Licitation.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data.Repository;

public class LicitationLandRepository : ILicitationLandRepository
{
    private readonly LicitationDBContext context;

    /// <summary>
    /// Initializes a new instance of the CommitteeMemberRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public LicitationLandRepository(LicitationDBContext context)
    {
        this.context = context;
    }
    
    /// <inheritdoc cref="ILicitationLandRepository.GetLicitationLand"/>
    public async Task<LicitationLand?> GetLicitationLand(Guid licitationId, Guid licitationLandId)
    {
        return await context.LicitationLands.FirstOrDefaultAsync(c => c.LandGuid == licitationLandId && c.LicitationGuid == licitationId);
    }

    /// <inheritdoc cref="ILicitationLandRepository.AddLicitationLand"/>
    /// 
    public async Task<LicitationLand?> AddLicitationLand(LicitationLand licitationLand)
    {
        var created = context.LicitationLands.Add(licitationLand);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="ILicitationLandRepository.DeleteLicitationLand"/>
    public async Task DeleteLicitationLand(Guid licitationId, Guid licitationLandId)
    {
        var licitationLand = await context.LicitationLands.FirstOrDefaultAsync(c => c.LandGuid == licitationLandId && c.LicitationGuid == licitationId);
        if (licitationLand == null)
        {
            throw new InvalidOperationException("licitation Land not found");
        }
        context.LicitationLands.Remove(licitationLand);
        await context.SaveChangesAsync();
    }
}
