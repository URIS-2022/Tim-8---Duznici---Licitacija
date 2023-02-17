using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data.Repository;

public class LeaseAgreementRepository : ILeaseAgreementRepository
{
    private readonly LeaseDbContext _context;

    public LeaseAgreementRepository(LeaseDbContext context)
    {
        _context = context;
    }

    public async Task<LeaseAgreement?> GetByGuid(Guid id)
    {
        return await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.Guid == id);
    }

    public async Task<List<LeaseAgreement>> GetAll()
    {
        return await _context.LeaseAgreements.ToListAsync();
    }

    public async Task<LeaseAgreement> Add(LeaseAgreement leaseAgreement)
    {
        await _context.LeaseAgreements.AddAsync(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    public async Task<LeaseAgreement> Update(LeaseAgreement leaseAgreement)
    {
        _context.LeaseAgreements.Update(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    public async Task<LeaseAgreement?> Delete(Guid id)
    {
        var leaseAgreement = await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.Guid == id);
        if (leaseAgreement == null) return null;

        _context.LeaseAgreements.Remove(leaseAgreement);
        await _context.SaveChangesAsync();
        return leaseAgreement;
    }

    public async Task<LeaseAgreement?> GetByReferenceNumber(string referenceNumber)
    {
        return await _context.LeaseAgreements.FirstOrDefaultAsync(la => la.ReferenceNumber == referenceNumber);
    }
}
