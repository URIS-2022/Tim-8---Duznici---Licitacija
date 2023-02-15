using Lease.API.Enums;

namespace Lease.API.Entities;

public class PriorityTypeEntity
{
    public int Id { get; set; }

    public ICollection<PriorityTypeEntity> PriorityTypes { get; set; }
    public ICollection<PriorityBuyer> PriorityBuyers { get; set; }
  
}
