using Lease.API.Entities;

namespace Lease.API.Data.Repository;

public interface ILeaseAgreementRepository
{
    Task<LeaseAgreement> GetByGuid(Guid id);
    Task<LeaseAgreement> GetByReferenceNumber(string referenceNumber);
    Task<List<LeaseAgreement>> GetAll();
    Task<LeaseAgreement> Add(LeaseAgreement leaseAgreement);
    Task<LeaseAgreement> Update(LeaseAgreement leaseAgreement);
    Task<LeaseAgreement> Delete(Guid id);
}
