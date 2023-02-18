using Lease.API.Entities;

namespace Lease.API.Data.Repository;

/// <summary>
/// Represents a repository for lease agreements.
/// </summary>
public interface ILeaseAgreementRepository
{
    /// <summary>
    /// Gets a specific lease agreement by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<LeaseAgreement?> GetByGuid(Guid id);

    /// <summary>
    /// Gets a specific lease agreement by its reference number.
    /// </summary>
    /// <param name="referenceNumber"></param>
    /// <returns></returns>
    Task<LeaseAgreement?> GetByReferenceNumber(string referenceNumber);

    /// <summary>
    /// Gets a list of all lease agreements.
    /// </summary>
    /// <returns></returns>
    Task<List<LeaseAgreement>> GetAll();
    
    /// <summary>
    /// Adds a new lease agreement.
    /// </summary>
    /// <param name="leaseAgreement"></param>
    /// <returns></returns>
    Task<LeaseAgreement> Add(LeaseAgreement leaseAgreement);

    /// <summary>
    /// Updates a specific lease agreement.
    /// </summary>
    /// <param name="leaseAgreement"></param>
    /// <returns></returns>
    Task<LeaseAgreement> Update(LeaseAgreement leaseAgreement);

    /// <summary>
    /// Deletes a specific lease agreement.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<LeaseAgreement?> Delete(Guid id);
}
