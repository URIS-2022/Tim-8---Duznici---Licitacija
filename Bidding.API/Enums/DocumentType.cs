using System.Text.Json;
using System.Text.Json.Serialization;


namespace Bidding.API.Enums
{

    /// <summary>
    /// Enumeration of document types.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// No document type assigned.
        /// </summary>
        None = 0,
        /// <summary>
        /// Report document type.
        /// </summary>
        Report


    }

    /// <summary>
    /// A custom JSON converter for serializing and deserializing .
    /// </summary>
    public class DocumentTypeConverter : JsonConverter<DocumentType>
    {
        private readonly Dictionary<DocumentType, string> _documentTypeMapping = new Dictionary<DocumentType, string>
        {
         { DocumentType.None, "Nije dodeljeno" },
         { DocumentType.Report, "Izvještaj" },
         

        };
        /// <inheritdoc/>

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

        /// <inheritdoc/>

        public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentTypeMapping[value]);
        }
    }
}
