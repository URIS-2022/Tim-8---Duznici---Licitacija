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

    /// <summary>
    /// The DocumentTypeConverter class provides a custom implementation for converting the DocumentType enum to and from JSON.
    /// </summary>
    public class DocumentTypeConverter : JsonConverter<DocumentType>
    {
        private readonly Dictionary<DocumentType, string> _documentTypeMapping = new Dictionary<DocumentType, string>
    {
        { DocumentType.Determining, "Odredjivanje nadleznog organa za javno nadmetanje" },
        { DocumentType.Request, "Zahtev odluke o raspisivanju" },
        { DocumentType.Proposal, "Predlog odluke o raspisivanju" },
        { DocumentType.Decision, "Odluka o raspisivanju javnog oglasa" },
    };

        /// <summary>
        /// Reads the DocumentType value from a JSON reader.
        /// </summary>
        /// <param name="reader">The JSON reader to read from.</param>
        /// <param name="typeToConvert">The type to convert to.</param>
        /// <param name="options">The JSON serializer options.</param>
        /// <returns>The DocumentType value read from the JSON reader.</returns>
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

        /// <summary>
        /// Writes the DocumentType value to a JSON writer.
        /// </summary>
        /// <param name="writer">The JSON writer to write to.</param>
        /// <param name="value">The DocumentType value to write.</param>
        /// <param name="options">The JSON serializer options.</param>
        public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_documentTypeMapping[value]);
        }
    }
}
