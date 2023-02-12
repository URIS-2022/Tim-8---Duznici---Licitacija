using Licitation.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data.Repository;

/// <summary>
/// Implementation of the ISystemUserRepository
/// interface for managing SystemUser entities in the database.
/// </summary>
public class LicitationRepository : ILicitationRepository
{
    private readonly LicitationDBContext context;

    /// <summary>
    /// Initializes a new instance of the LicitationRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public LicitationRepository(LicitationDBContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IComplaintRepository.GetAll"/>
    public async Task<IEnumerable<Entities.LicitationEntity>> GetAll()
    {
        return await context.LicitationEntities.ToListAsync();
    }

    /// <inheritdoc cref="ILicitationRepository.GetByGuid"/>
    public async Task<LicitationEntity?> GetByGuid(Guid id)
    {
        return await context.LicitationEntities.FindAsync(id);
    }

    /// <inheritdoc cref="ILicitationRepository.Delete"/>
    public async Task Delete(Guid id)
    {
        var licitation = await context.LicitationEntities.FindAsync(id);
        if (licitation == null)
        {
            throw new InvalidOperationException("Licitation not found");
        }
        context.LicitationEntities.Remove(licitation);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="ILicitationRepository.AddLicitation"/>
    public async Task<Entities.LicitationEntity?> AddLicitation(Entities.LicitationEntity licitation)
    {
        var created = context.LicitationEntities.Add(licitation);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="ILicitationRepository.UpdateLicitation"/>
    public async Task<Entities.LicitationEntity?> UpdateLicitation(Guid id, Entities.LicitationEntity updateModel)
    {
        var licitation = await context.LicitationEntities.FirstOrDefaultAsync(c => c.Guid == id);
        if (licitation == null)
        {
            return null;
        }
        context.Entry(licitation).CurrentValues.SetValues(updateModel);
        await context.SaveChangesAsync();
        return licitation;
    }

    /*/// <inheritdoc cref="ILicitationRepository.Delete(DateTime)"/>
    public async Task Delete(string date)
    {
        var licitation = await context.LicitationEntities.FirstOrDefaultAsync(x => x.Date == date);
        if (date == null)
        {
            throw new InvalidOperationException("Licitation not found");
        }
        context.LicitationEntities.Remove(licitation);
        await context.SaveChangesAsync();
    }*/


    /*/// <inheritdoc cref="ILicitationRepository.GetByDate(DateTime)"/>
    public async Task<LicitationEntity?> GetByDate(DateTime date)
    {
        LicitationEntity? licitation = await context.LicitationEntities.SingleOrDefaultAsync(x => x.Date == date);

        return licitation;
    }
    */


}