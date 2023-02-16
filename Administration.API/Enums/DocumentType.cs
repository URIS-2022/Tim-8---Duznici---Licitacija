using System.Text.Json;
using System.Text.Json.Serialization;

namespace Administration.API.Enums;

public enum DocumentType
{
    CommitteePlan,
    YearPlanDraft,
    YearPlanFinal
}

/// <summary>
/// The DocumentTypeConverter class provides a custom implementation for converting the DocumentType enum to and from JSON.
/// </summary>
public class DocumentTypeConverter : JsonConverter<DocumentType>
{
    private readonly Dictionary<DocumentType, string> _typeMapping = new()
    {
    { DocumentType.CommitteePlan, "Rešenje o obrazovanju komisije" },
    { DocumentType.YearPlanDraft, "Predlog plana godišnjeg programa" },
    { DocumentType.YearPlanFinal, "Plan godišnjeg programa" }
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
        string typeString = reader.GetString() ?? "Rešenje o obrazovanju komisije";
        foreach (var typeMapping in _typeMapping)
        {
            if (typeMapping.Value == typeString)
            {
                return typeMapping.Key;
            }
        }

        throw new JsonException($"Unable to map role string '{typeString}' to DocumentType.");
    }

    /// <summary>
    /// Writes the DocumentType value to a JSON writer.
    /// </summary>
    /// <param name="writer">The JSON writer to write to.</param>
    /// <param name="value">The DocumentType value to write.</param>
    /// <param name="options">The JSON serializer options.</param>
    public override void Write(Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_typeMapping[value]);
    }
}
