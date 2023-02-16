using System.Text.Json.Serialization;
using System.Text.Json;

namespace Preparation.API.Enums
{
    /// <summary>
    /// Represents the possible status values for a document.
    /// </summary>
    public enum DocumentStatus
    {
        /// <summary>
        /// The document has been approved.
        /// </summary>
        Approved,

        /// <summary>
        /// The document has been rejected.
        /// </summary>
        Rejected,

        /// <summary>
        /// The document is currently open.
        /// </summary>
        Opened
    }

    /// <summary>
    /// Converts between <see cref="DocumentStatus"/> enum and JSON string representation of the status.
    /// </summary>
    public class DocumentStatusConverter : JsonConverter<DocumentStatus>
    {
        // A mapping between DocumentStatus enum values and their JSON string representation.
        private readonly Dictionary<DocumentStatus, string> _documentStatusMapping = new Dictionary<DocumentStatus, string>
    {
        { DocumentStatus.Approved, "Usvojen" },
        { DocumentStatus.Rejected, "Odbijen" },
        { DocumentStatus.Opened, "Otvoren" },
    };

        /// <inheritdoc />
        public override DocumentStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Reads the JSON string representation of the status and converts it to DocumentStatus enum value.
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

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DocumentStatus value, JsonSerializerOptions options)
        {
            // Writes the JSON string representation of the status for the given DocumentStatus enum value.
            writer.WriteStringValue(_documentStatusMapping[value]);
        }
    }
}
