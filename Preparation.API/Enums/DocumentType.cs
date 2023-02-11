using System.Text.Json.Serialization;
using System.Text.Json;

namespace Preparation.API.Enums
{
    public enum DocumentType
    {
        Determining,
        Request,
        Proposal,
        Decision
    }

    public class DocumentTypeConverter : JsonConverter<DocumentType>
    {
        private readonly Dictionary<DocumentType, string> _documentTypeMapping = new Dictionary<DocumentType, string>
    {
        { DocumentType.Determining, "Odredjivanje nadleznog organa za javno nadmetanje" },
        { DocumentType.Request, "Zahtev odluke o raspisivanju" },
        { DocumentType.Proposal, "Predlog odluke o raspisivanju" },
        { DocumentType.Decision, "Odluka o raspisivanju javnog oglasa" },
    };

        public override DocumentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string typeString = reader.GetString() ?? "Odredjivanje nadleznog organa za javno nadmetanje";
            foreach (var documentTypeMapping in _documentTypeMapping)
            {
                if (documentTypeMapping.Value == typeString)
                {
                    return documentTypeMapping.Key;
                }
            }

            throw new JsonException($"Unable to map type string '{typeString}' to DocumentType.");
        }

        public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentTypeMapping[value]);
        }
    }
}
