namespace Lease.API.Entities;

/// <summary>
/// Represents a buyer with its properties and associated entities.
/// </summary>
public class PriorityBuyer
{
    /// <summary>
    /// Gets or sets the unique identifier of the buyer.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the buyer.
    /// </summary>
    public virtual Buyer Buyer { get; set; }

    /// <summary>
    /// Gets or sets the buyer guid.
    /// </summary>
    public Guid BuyerGuid { get; set; }

    /// <summary>
    /// Gets or sets the priority type.
    /// </summary>
    public int PriorityTypeId { get; set; }

}