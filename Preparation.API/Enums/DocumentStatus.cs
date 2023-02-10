using System.Text.Json.Serialization;
using System.Text.Json;

namespace Preparation.API.Enums
{
    public enum DocumentStatus
    {
        Approved,
        Rejected,
        Opened
    }

    public class DocumentStatusConverter : JsonConverter<DocumentStatus>
    {
        private readonly Dictionary<DocumentStatus, string> _documentStatusMapping = new Dictionary<DocumentStatus, string>
    {
        { DocumentStatus.Approved, "Usvojen" },
        { DocumentStatus.Rejected, "Odbijen" },
        { DocumentStatus.Opened, "Otvoren" },
    };

        public override DocumentStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string statusString = reader.GetString() ?? "Otvoren";
            foreach (var documentStatusMapping in _documentStatusMapping)
            {
                if (documentStatusMapping.Value == statusString)
                {
                    return documentStatusMapping.Key;
                }
            }

            throw new JsonException($"Unable to map status string '{statusString}' to DocumentStatus.");
        }

        public override void Write(Utf8JsonWriter writer, DocumentStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentStatusMapping[value]);
        }
    }
}
