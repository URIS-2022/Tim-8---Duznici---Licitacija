using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository;

/// <summary>
/// Represents a repository for buyers.
/// </summary>
public class BuyerRepository : IBuyerRepository
{
    private readonly LeaseDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BuyerRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public BuyerRepository(LeaseDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc cref="IBuyerRepository.GetByGuid(Guid)"/>
    public async Task<Buyer?> GetByGuid(Guid id)
    {
        return await _context.Buyers.FirstOrDefaultAsync(b => b.Guid == id);
    }

    /// <inheritdoc cref="IBuyerRepository.GetAll"/>
    public async Task<List<Buyer>> GetAll()
    {
        return await _context.Buyers.ToListAsync();
    }

    /// <inheritdoc cref="IBuyerRepository.Add(Buyer)"/>
    public async Task<Buyer?> Add(Buyer buyer)
    {
        await _context.Buyers.AddAsync(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }

    /// <inheritdoc cref="IBuyerRepository.Update(Buyer)"/>
    public async Task<Buyer?> Update(Buyer buyer)
    {
        _context.Buyers.Update(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }
    /// <inheritdoc cref="IBuyerRepository.Delete(Guid)"/>
    public async Task<Buyer?> Delete(Guid id)
    {
        var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.Guid == id);
        if (buyer == null) return null;

        _context.Buyers.Remove(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }
}