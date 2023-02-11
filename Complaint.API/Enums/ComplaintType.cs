using System.Text.Json;
using System.Text.Json.Serialization;

namespace Complaint.API.Enums;

public enum ComplaintType
{
    None = 0,
    BiddingComplaint,
    LeaseComplaint,
    UsePermitComplaint
}

public class ComplaintTypeConverter : JsonConverter<ComplaintType>
{
    private readonly Dictionary<ComplaintType, string> _typeMapping = new()
    {
        { ComplaintType.None, "Nije dodeljeno" },
        { ComplaintType.BiddingComplaint, "Žalba na tok javnog nadmetanja" },
        { ComplaintType.LeaseComplaint, "Žalba na Odluku o davanju u zakup" },
        { ComplaintType.UsePermitComplaint, "Žalba na Odluku o davanju na korišćenje" }
    };

    public override ComplaintType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string typeString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var typeMapping in _typeMapping)
        {
            if (typeMapping.Value == typeString)
            {
                return typeMapping.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{typeString}' to complaint type.");
    }

    public override void Write(Utf8JsonWriter writer, ComplaintType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_typeMapping[value]);
    }
}
