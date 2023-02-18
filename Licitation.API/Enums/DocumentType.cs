using System.Text.Json.Serialization;
using System.Text.Json;

namespace Licitation.API.Enums
{

    /// <summary>
    /// Enumeration representing different types of documents that can be associated with a licitation.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// No document type assigned.
        /// </summary>
        None = 0,
        /// <summary>
        /// Document type for preparation of the bidding report.
        /// </summary>
        PreparationOfTheBiddingReport

    }
    /// <summary>
    /// JsonConverter implementation to serialize and deserialize the DocumentType enumeration.
    /// </summary>
    public class DocumentTypeConverter : JsonConverter<DocumentType>
    {
        private readonly Dictionary<DocumentType, string> _documentTypeMapping = new Dictionary<DocumentType, string>
        {
         { DocumentType.None, "Nije dodeljeno" },
         { DocumentType.PreparationOfTheBiddingReport, "Izrada izvestaja licitiranja" }

        };

        /// <summary>
        /// Reads the JSON representation of the enumeration and maps it to a DocumentType value.
        /// </summary>
        public override DocumentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string documentTypeString = reader.GetString() ?? "Nije dodeljeno";
            foreach (var documentTypeMapping in _documentTypeMapping)
            {
                if (documentTypeMapping.Value == documentTypeString)
                {
                    return documentTypeMapping.Key;
                }
            }

            throw new JsonException($"Unable to map document type string '{documentTypeString}' to DocumentType.");
        }
        /// <summary>
        /// Writes the DocumentType value to its JSON representation.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentTypeMapping[value]);
        }
    }
}
