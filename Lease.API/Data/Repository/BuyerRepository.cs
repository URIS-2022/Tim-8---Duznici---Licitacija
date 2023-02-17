using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository;

public class BuyerRepository : IBuyerRepository
{
    private readonly LeaseDbContext _context;

    public BuyerRepository(LeaseDbContext context)
    {
        _context = context;
    }

    public async Task<Buyer?> GetByGuid(Guid id)
    {
        return await _context.Buyers.FirstOrDefaultAsync(b => b.Guid == id);
    }

    public async Task<List<Buyer>> GetAll()
    {
        return await _context.Buyers.ToListAsync();
    }

    public async Task<Buyer> Add(Buyer buyer)
    {
        await _context.Buyers.AddAsync(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }

    public async Task<Buyer> Update(Buyer buyer)
    {
        _context.Buyers.Update(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }

    public async Task<Buyer?> Delete(Guid id)
    {
        var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.Guid == id);
        if (buyer == null) return null;

        _context.Buyers.Remove(buyer);
        await _context.SaveChangesAsync();
        return buyer;
    }
}