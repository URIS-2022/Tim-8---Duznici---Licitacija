using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Lease.API.Enums;

namespace Lease.API.Entities;

/// <summary>
/// Represents a lease agreement entity with its properties and methods.
/// </summary>
public class PriorityTypeListValueConverter : ValueConverter<List<PriorityType>?, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityTypeListValueConverter"/> class.
    /// </summary>
    public PriorityTypeListValueConverter() : base(
        v => JsonSerializer.Serialize(v, typeof(List<PriorityType>), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
        v => JsonSerializer.Deserialize<List<PriorityType>?>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }))
    { }
}