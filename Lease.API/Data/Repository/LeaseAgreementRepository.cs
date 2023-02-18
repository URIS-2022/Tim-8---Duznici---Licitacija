using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository;

/// <summary>
/// Represents a repository for lease agreements.
/// </summary>
public class LeaseAgreementRepository : ILeaseAgreementRepository
{
    private readonly LeaseDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="LeaseAgreementRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public LeaseAgreementRepository(LeaseDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.GetByGuid(Guid)"/>
    public async Task<LeaseAgreement?> GetByGuid(Guid id)
    {
        return await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.Guid == id);
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.GetAll"/>
    public async Task<List<LeaseAgreement>> GetAll()
    {
        return await _context.LeaseAgreements.ToListAsync();
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.Add(LeaseAgreement)"/>
    public async Task<LeaseAgreement> Add(LeaseAgreement leaseAgreement)
    {
        await _context.LeaseAgreements.AddAsync(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.Update(LeaseAgreement)"/>
    public async Task<LeaseAgreement> Update(LeaseAgreement leaseAgreement)
    {
        _context.LeaseAgreements.Update(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.Delete"/>
    public async Task<LeaseAgreement?> Delete(Guid id)
    {
        var leaseAgreement = await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.Guid == id);
        if (leaseAgreement == null) return null;

        _context.LeaseAgreements.Remove(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    /// <inheritdoc cref="ILeaseAgreementRepository.GetByReferenceNumber(string)"/>
    public async Task<LeaseAgreement?> GetByReferenceNumber(string referenceNumber)
    {
        return await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.ReferenceNumber == referenceNumber);
    }
}
