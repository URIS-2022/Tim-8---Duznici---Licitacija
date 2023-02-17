namespace Licitation.API.Data.Repository;

public interface ILicitationPublicBiddingRepository
{
    /// <summary>
    /// Gets a specific licitation public bidding by its identifier.
    /// </summary>
    /// <param name="licitationId">The identifier of the Licitation.</param>
    /// /// <param name="publicBiddingId">The id of public bidding to add.</param>
    /// <returns>The member with the specified identifier.</returns>
    Task<Entities.PublicBidding?> GetPublicBidding(Guid licitationId, Guid publicBiddingId);

    /// <summary>
    /// Adds a new public bidding to licitation.
    /// </summary>
    /// <param name="publicBidding">The request format for adding public bidding to licitation.</param>
    /// <returns>The added public bidding.</returns>
    Task<Entities.PublicBidding?> AddPublicBidding(Entities.PublicBidding publicBidding);

    /// <summary>
    /// Removes a specific public bidding from licitation.
    /// </summary>
    /// <param name="licitationId">The identifier of the public bidding to delete.</param>
    /// /// <param name="publicBiddingId">The id of public bidding to remove.</param>
    /// <returns>The deleted public bidding.</returns>
    Task DeletePublicBidding(Guid licitationId, Guid publicBiddingId);
}
