using Lease.API.Enums;

namespace Lease.API.Entities;

public class PriorityBuyer
{
    public int Id { get; set; }

    public virtual Buyer Buyer {get; set;}

    public Guid BuyerGuid { get; set; }

    public int PriorityTypeId { get; set; }

}