using System.Text.Json.Serialization;
using System.Text.Json;

namespace Complaint.API.Enums;

public enum ComplaintStatus
{
    Opened = 0,
    Rejected,
    Accepted
}

public class ComplaintStatusConverter : JsonConverter<ComplaintStatus>
{
    private readonly Dictionary<ComplaintStatus, string> _statusMapping = new()
    {
        { ComplaintStatus.Opened, "Otvorena" },
        { ComplaintStatus.Rejected, "Odbijena" },
        { ComplaintStatus.Accepted, "Usvojena" }
    };

    public override ComplaintStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string statusString = reader.GetString() ?? "Otvorena";
        foreach (var status in _statusMapping)
        {
            if (status.Value == statusString)
            {
                return status.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{statusString}' to complaint status.");
    }

    public override void Write(Utf8JsonWriter writer, ComplaintStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_statusMapping[value]);
    }
}
