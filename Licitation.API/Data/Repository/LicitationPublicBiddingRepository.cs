using Licitation.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data.Repository;

public class LicitationPublicBiddingRepository : ILicitationPublicBiddingRepository
{
    private readonly LicitationDBContext context;

    /// <summary>
    /// Initializes a new instance of the PublicBiddingRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public LicitationPublicBiddingRepository(LicitationDBContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="ILicitationPublicBiddingRepository.GetPublicBidding"/>
    public async Task<PublicBidding?> GetPublicBidding(Guid licitationId, Guid publicBiddingId)
    {
        return await context.LicitationPublicBiddings.FirstOrDefaultAsync(c => c.PublicBiddingGuid == publicBiddingId && c.LicitationGuid == licitationId);
    }

    /// <inheritdoc cref="ILicitationPublicBiddingRepository.AddPublicBidding"/>
    /// 
    public async Task<PublicBidding?> AddPublicBidding(PublicBidding publicBidding)
    {
        var created = context.LicitationPublicBiddings.Add(publicBidding);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="ILicitationPublicBiddingRepository.DeletePublicBidding"/>
    public async Task DeletePublicBidding(Guid licitationId, Guid publicBiddingId)
    {
        var publicBidding = await context.LicitationPublicBiddings.FirstOrDefaultAsync(c => c.PublicBiddingGuid == publicBiddingId && c.LicitationGuid == licitationId);
        if (publicBidding == null)
        {
            throw new InvalidOperationException("Public bidding not found");
        }
        context.LicitationPublicBiddings.Remove(publicBidding);
        await context.SaveChangesAsync();
    }
}
