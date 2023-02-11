using System.Text.Json.Serialization;
using System.Text.Json;

namespace Licitation.API.Enums
{


    public enum DocumentType
    {
        None = 0,
        PreparationOfTheBiddingReport

    }
    public class DocumentTypeConverter : JsonConverter<DocumentType>
    {
        private readonly Dictionary<DocumentType, string> _documentTypeMapping = new Dictionary<DocumentType, string>
        {
         { DocumentType.None, "Nije dodeljeno" },
         { DocumentType.PreparationOfTheBiddingReport, "Izrada izvestaja licitiranja" }

        };

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

        public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentTypeMapping[value]);
        }
    }
}
