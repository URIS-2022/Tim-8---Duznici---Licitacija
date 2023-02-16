using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Lease.API.Enums;
namespace Lease.API.Entities;
public class PriorityTypeListJsonConverter : ValueConverter<List<PriorityType>, string>
{
    public PriorityTypeListJsonConverter() : base(
        v => JsonSerializer.Serialize(v, typeof(List<PriorityType>), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
        v => JsonSerializer.Deserialize<List<PriorityType>>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }))
    {
    }

   

    
    
}
