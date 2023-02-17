using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Enums;
public enum DocumentType
{
    None = 0,
    LeaseProposition,
    LeaseDecision
}

[NotMapped]
public class DocumentTypeConverter : JsonConverter<DocumentType>
{
    private readonly Dictionary<DocumentType, string> _roleMapping = new Dictionary<DocumentType, string>
    {
        { DocumentType.None, "Nije dodeljeno" },
        { DocumentType.LeaseProposition, "Predlog odluke o davanju u zakup" },
        { DocumentType.LeaseDecision, "Odluka o davanju u zakup" }
    };

    public override DocumentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string roleString = reader.GetString() ?? "Nije dodeljeno";
        foreach (var roleMapping in _roleMapping)
        {
            if (roleMapping.Value == roleString)
            {
                return roleMapping.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{roleString}' to DocumentType.");
    }

    public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_roleMapping[value]);
    }
}
