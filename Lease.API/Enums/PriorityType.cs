using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Enums;

public enum PriorityType
{
    None = 0,
    Irrigation,
    Border,
    Registry,
    Location
}



[NotMapped]
public class PriorityTypeConverter : JsonConverter<PriorityType>


{


    private readonly Dictionary<PriorityType, string> _PriorityTypeMapping = new Dictionary<PriorityType, string>
{
    { PriorityType.None, "Nije dodeljeno" },
    { PriorityType.Irrigation, "Ima sistem za navodnjavanje" },
    { PriorityType.Border, "Granici se sa zemljistem" },
    { PriorityType.Registry, "Upisan u registar" },
    {  PriorityType.Location, "Najblize zemljistu"  },

};

    public override PriorityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string PriorityTypeString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var PriorityTypeMapping in _PriorityTypeMapping)
        {
            if (PriorityTypeMapping.Value == PriorityTypeString)
            {
                return PriorityTypeMapping.Key;
            }
        }

        throw new JsonException($"Unable to map Priority Type string '{PriorityTypeString}' to PriorityType.");
    }

    public override void Write(Utf8JsonWriter writer, PriorityType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_PriorityTypeMapping[value]);
    }
}

