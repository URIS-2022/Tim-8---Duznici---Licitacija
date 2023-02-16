using Lease.API.Enums;
using Lease.API.Models.Buyer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Lease.API.Entities;

public class PriorityTypeEntity
{
    public int Id { get; set; }

    [NotMapped]
    public List<PriorityType> PriorityTypes { get; set; }

  //  public ICollection<PriorityBuyer> PriorityBuyers { get; set; }
  
}


