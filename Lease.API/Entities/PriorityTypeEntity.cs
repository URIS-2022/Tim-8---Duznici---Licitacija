using Lease.API.Enums;


using System.Text.Json;
using System.Text.Json.Serialization;


namespace Lease.API.Entities;

public class PriorityTypeEntity
{
    public int Id { get; set; }

    [JsonConverter(typeof(PriorityTypeListJsonConverter))]
    public List<PriorityType> PriorityTypes { get; set; }

  //  public ICollection<PriorityBuyer> PriorityBuyers { get; set; }
  
}


/*public class PriorityTypeListConverter : Newtonsoft.Json.JsonConverter<List<PriorityType>>
{
public override List<PriorityType> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    var json = reader.GetString();
    return JsonConvert.DeserializeObject<List<PriorityType>>(json);
}
public override List<PriorityType>? ReadJson(JsonReader reader, Type objectType, List<PriorityType>? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
{
    throw new NotImplementedException();
}

public override void Write(Utf8JsonWriter writer, List<PriorityType> value, JsonSerializerOptions options)
{
    var json = JsonConvert.SerializeObject(value);
    writer.WriteStringValue(json);
}

public override void WriteJson(JsonWriter writer, List<PriorityType>? value, Newtonsoft.Json.JsonSerializer serializer)
{
    throw new NotImplementedException();
}

*/

