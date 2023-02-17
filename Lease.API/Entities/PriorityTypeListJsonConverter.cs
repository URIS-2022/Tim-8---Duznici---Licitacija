using Lease.API.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Entities;
public class PriorityTypeListJsonConverter : JsonConverter<List<PriorityType>>
{
    private readonly Dictionary<PriorityType, string> _priorityTypeMapping = new Dictionary<PriorityType, string>
    {
        { PriorityType.None, "Nije dodeljeno" },
        { PriorityType.Irrigation, "Ima sistem za navodnjavanje" },
        { PriorityType.Border, "Granici se sa zemljistem" },
        { PriorityType.Registry, "Upisan u registar" },
        { PriorityType.Location, "Najblize zemljistu" },
    };

    public override List<PriorityType> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var priorityTypes = new List<PriorityType>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var priorityTypeString = reader.GetString();
                foreach (var mapping in _priorityTypeMapping)
                {
                    if (mapping.Value == priorityTypeString)
                    {
                        priorityTypes.Add(mapping.Key);
                        break;
                    }
                }
            }
        }
        return priorityTypes;
    }

    public override void Write(Utf8JsonWriter writer, List<PriorityType> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var priorityType in value)
        {
            writer.WriteStringValue(_priorityTypeMapping[priorityType]);
        }
        writer.WriteEndArray();
    }
}



/*


*/