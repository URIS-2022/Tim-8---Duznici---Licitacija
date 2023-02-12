using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Enums;

public enum DocumentStatus
{
    None = 0,
    Open,
    Declined,
    Approved
}

[NotMapped]
public class DocumentStatusConverter : JsonConverter<DocumentStatus>
{
    private readonly Dictionary<DocumentStatus, string> _documentStatusMapping = new Dictionary<DocumentStatus, string>
{
    { DocumentStatus.None, "Nije dodeljeno" },
    { DocumentStatus.Open, "Otvoren" },
    { DocumentStatus.Declined, "Odbijen" },
    { DocumentStatus.Approved, "Odobren" }

};

    public override DocumentStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string documentStatusString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var documentStatusMapping in _documentStatusMapping)
        {
            if (documentStatusMapping.Value == documentStatusString)
            {
                return documentStatusMapping.Key;
            }
        }

        throw new JsonException($"Unable to map document status string '{documentStatusString}' to DocumentStatus.");
    }

    public override void Write(Utf8JsonWriter writer, DocumentStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_documentStatusMapping[value]);
    }
}

