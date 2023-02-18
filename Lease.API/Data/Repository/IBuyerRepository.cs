using Lease.API.Entities;

namespace Lease.API.Data.Repository;

/// <summary>
/// Represents a repository for buyers.
/// </summary>
public interface IBuyerRepository
{
    /// <summary>
    /// Gets a specific buyer by its identifier.
    /// </summary>
    /// <param name="id"> The identifier of the buyer.</param>
    /// <returns> The buyer with the specified identifier.</returns>
    Task<Buyer?> GetByGuid(Guid id);

    /// <summary>
    /// Gets a list of all buyers.
    /// </summary>
    /// <returns> A list of buyers.</returns>
    Task<List<Buyer>> GetAll();

    /// <summary>
    /// Adds a new buyer.
    /// </summary>
    /// <param name="buyer"> The buyer to add.</param>
    /// <returns> The added buyer.</returns>
    Task<Buyer?> Add(Buyer buyer);

    /// <summary>
    /// Updates a specific buyer.
    /// </summary>
    /// <param name="buyer"> The buyer to update.</param>
    /// <returns> The updated buyer.</returns>
    Task<Buyer?> Update(Buyer buyer);

    /// <summary>
    /// Deletes a specific buyer.
    /// </summary>
    /// <param name="id"> The identifier of the buyer to delete.</param>
    /// <returns> The deleted buyer.</returns>
    Task<Buyer?> Delete(Guid id);
}

