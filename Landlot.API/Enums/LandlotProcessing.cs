using System.Text.Json.Serialization;
using System.Text.Json;

namespace Landlot.API.Enums
{
    /// <summary>
    /// Specifies the type of processing that can be done on a land lot.
    /// </summary>
    public enum LandlotProcessing
    {
        /// <summary>
        /// The land lot is arable and can be used for cultivation or other agricultural activities.
        /// </summary>
        Obradivo,
        /// <summary>
        /// The land lot is not arable and cannot be used for cultivation or other agricultural activities.
        /// </summary>
        Ostalo
    }
    /// <summary>
    /// Converts a <see cref="LandlotProcessing"/> value to and from JSON.
    /// </summary>
    public class LandlotProcessingConverter : JsonConverter<LandlotProcessing>
    {
        private readonly Dictionary<LandlotProcessing, string> _processingMapping = new()
    {
        { LandlotProcessing.Obradivo, "Obradivo" },
        { LandlotProcessing.Ostalo, "Ostalo" }
    };

        /// <summary>
        /// Reads and converts the JSON representation of the <see cref="LandlotProcessing"/> enumeration.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON.</param>
        /// <param name="typeToConvert">The type of object being converted.</param>
        /// <param name="options">The serializer options to use.</param>
        /// <returns>The deserialized <see cref="LandlotProcessing"/> enumeration value.</returns>
        public override LandlotProcessing Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? processingString = reader.GetString() ?? "Ostalo";
            foreach (var processing in _processingMapping)
            {
                if (processing.Value == processingString)
                {
                    return processing.Key;
                }
            }

            throw new JsonException($"Unable to map processing string '{processingString}' to LandlotProcessing.");
        }

        /// <summary>
        /// Writes the JSON representation of the specified <see cref="LandlotProcessing"/> enumeration value.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON.</param>
        /// <param name="value">The <see cref="LandlotProcessing"/> enumeration value to write.</param>
        /// <param name="options">The serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, LandlotProcessing value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_processingMapping[value]!);
        }
    }

}
